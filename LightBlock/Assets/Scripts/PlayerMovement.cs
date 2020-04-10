using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{

    public bool gameStart;
    public int directionChange;
    public float speedMultiplier;
    public PlayerVelocity velocity;
    public int currentDirection;
    public float resumedXVelocity;
    public float guivelocity;
    public const float XVELOCITY = .07f;
    public Rigidbody rb;
    public Transform center;
    public GameObject top;
    public Player player;
    public GameObject impact;
    public GameObject blueImpact;
    public Vector3 mPrevPos;
    public float radius;
    public float power;

    
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        directionChange = -1;
        speedMultiplier = 1;
        currentDirection = 1;
        resumedXVelocity = 0f;
        velocity = new PlayerVelocity(XVELOCITY,0f);
        rb = GetComponent<Rigidbody>();
        mPrevPos = transform.position;
        radius = 5.0F;
        power = 300.0F;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Magnitude(transform.position - center.position) > (top.transform.localScale.x * 1.25f))
        {
            //TODO
            player.SavePlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            currentDirection *= directionChange;

            if (velocity.x == 0)
            {
                velocity.x = resumedXVelocity;
                velocity.z = 0;
                speedMultiplier = 1;
            }
            
            if (!gameStart)
            {
                gameStart = true;
                Vector2 v = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                velocity.z = 0f;
                if (v.x >= .5f)
                {
                    currentDirection = -1;
                    velocity.x *= -1;
                }
            }
            
            velocity.x *= directionChange;
            speedMultiplier += .05f;
            speedMultiplier = Mathf.Clamp(speedMultiplier, 0f, 1.6f);
            velocity.x *= speedMultiplier;
            velocity.x = Mathf.Clamp(velocity.x, -1f, 1);
        }

        guivelocity = velocity.x;

        if (gameStart)
        {
            mPrevPos = transform.position;
            transform.Translate( velocity.x,0,velocity.z);
            RaycastHit[] rArray= Physics.RaycastAll(new Ray(mPrevPos, (transform.position- mPrevPos).normalized),(transform.position-mPrevPos).magnitude);
            GameObject closestGo = null;
            int closestGameObjectIndex = 0;
            for (int i = 0; i < rArray.Length; i++)
            {
                if (rArray[i].collider.gameObject != gameObject)
                {
                    if (closestGo == null)
                    {

                        closestGo = rArray[i].collider.gameObject;
                    }

                    else if ((rArray[i].collider.gameObject.transform.position - transform.position).magnitude >
                             (closestGo.transform.position - transform.position).magnitude)

                    {
                        closestGo = rArray[i].collider.gameObject;
                        closestGameObjectIndex = i;
                    }
                }
            }

            if (closestGo != null)
            {
                transform.position = mPrevPos;
                handleCollision(closestGo, rArray[closestGameObjectIndex].point); //TODO remove all code from on trigger enter ...also look for difference between the two
            }
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        handleCollision(other.gameObject, other.ClosestPoint(transform.position));
    }

    public void handleCollision(GameObject other, Vector3 r)

    {
        if (other.CompareTag("Brick"))
        {
            if (other.GetComponent<Movement>().transform.position.x < transform.position.x)
            {
                //if (!Input.GetMouseButton(0))
                {
                    resumedXVelocity = XVELOCITY*-1f;
                    velocity.x = 0f;
                    velocity.z = other.GetComponent<Movement>().speed;
                }
                //else
                {
                                
//                    velocity.x *= directionChange;
//                    speedMultiplier += .05f;
//                    speedMultiplier = Mathf.Clamp(speedMultiplier, 0f, 1.6f);
//                    velocity.x *= speedMultiplier;
//                    velocity.x = Mathf.Clamp(velocity.x, -1f, 1);

                    
                }
                    
                transform.Translate(other.GetComponent<Movement>().transform.position.x-transform.position.x+other.GetComponent<Movement>().transform.localScale.x,0,velocity.z);
            }
            else if(other.GetComponent<Movement>().transform.position.x > transform.position.x)
            {
                //if (!Input.GetMouseButton(0))
                {
                    resumedXVelocity = XVELOCITY;
                    velocity.x = 0f;
                    velocity.z = other.GetComponent<Movement>().speed;
                }

                //else
                {
                                
//                    velocity.x *= directionChange;
//                    speedMultiplier += .05f;
//                    speedMultiplier = Mathf.Clamp(speedMultiplier, 0f, 1.6f);
//                    velocity.x *= speedMultiplier;
//                    velocity.x = Mathf.Clamp(velocity.x, -1f, 1);


                }
                transform.Translate(other.GetComponent<Movement>().transform.position.x-transform.position.x-other.GetComponent<Movement>().transform.localScale.x,0,velocity.z);
            }
            else
            {
                player.SavePlayer();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            Brick b = other.GetComponent<Brick>();
            if (b != null)
            {
                b.SetColor();
            
            }

            player.gm.GetComponent<PowerUpManager>().SpawnPowerUp(other.transform);
            GameObject effect = Instantiate(impact, r, transform.rotation);
            Vector3 dir = transform.position - r;
            effect.transform.rotation = Quaternion.LookRotation(dir);
            var emptyObject = new GameObject();
            emptyObject.transform.parent = other.transform;
            effect.transform.parent = emptyObject.transform;
            Destroy(effect, 1.5f);
            
            for (int i = 0; i < 1; i++)
            {
                GameObject blueEffect = Instantiate(blueImpact, r, transform.rotation); //TODO spread out over a few frames. doesnt need to be done all at once (coroutine)
                Vector3 dir2 = transform.position - r;
                blueEffect.transform.rotation = Quaternion.LookRotation(dir2);
                var emptyObject2 = new GameObject();
                emptyObject2.transform.parent = other.transform;
                blueEffect.transform.parent = emptyObject2.transform;
                Destroy(blueEffect, 1.5f);
            }
            
            //gameController.GetComponent<Score>().score +=1;
            player.hitNumScore +=1;
        }
        else if (other.CompareTag("PowerUp"))
        {
            
            Debug.Log("hit: " + other.tag);
            player.AbsorbPowerUp(other.gameObject.transform.parent.gameObject);

        }
    }
}


public struct PlayerVelocity
{
    public float x, z;

    public PlayerVelocity(float p1, float p2)
    {
        x = p1;
        z = p2;
    }
}
