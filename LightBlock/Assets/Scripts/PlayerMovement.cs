using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{

    public bool gameStart;
    //private float xVelocity;
    //private float yVelocity;
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

    //public int score;
    
    //public Score score;

    //public GameObject gameController;
    /////public GameObject gameController;
    ///
    ///
    public Player player;
    public GameObject impact;
    public GameObject blueImpact;

    public Vector3 mPrevPos;

    public float radius;
    public float power;

    
    

    //public GameObject impactEffect;
    
    // Start is called before the first frame update
    void Start()
    {

        gameStart = false;
        directionChange = -1;
        speedMultiplier = 1;
        currentDirection = 1;
        //xVelocity = XVELOCITY;
        //yVelocity = 0f;
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
            
            //Debug.Log(score.score);
            
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
            //Debug.Log(Time.deltaTime);

            //transform.position.x
            //rb.MovePosition(new Vector3(transform.position.x+velocity.x,transform.position.y,transform.position.z+velocity.z));
            //transform.Translate(Time.deltaTime * velocity.x * 60,0,Time.deltaTime* velocity.z*60); //TODO
            
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




                //Debug.Log(rArray[i].collider.gameObject.name);
            }

            if (closestGo != null)
            {
                transform.position = mPrevPos;
                //Vector3 closestPosition = (Vector3)rArray[closestGameObjectIndex].point;
                handleCollision(closestGo, rArray[closestGameObjectIndex].point); //TODO remove all code from on trigger enter ...also look for difference between the two
            
            }
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("SOMETHINGs HIT");
        
        
        handleCollision(other.gameObject, other.ClosestPoint(transform.position));
       
//        if (other.CompareTag("Brick"))
//        {
//
//
//            if (other.GetComponent<Movement>().transform.position.x < transform.position.x)
//            {
//                resumedXVelocity = XVELOCITY*-1f;
//                transform.Translate(other.GetComponent<Movement>().transform.position.x-transform.position.x+other.GetComponent<Movement>().transform.localScale.x,0,velocity.z);
//            }
//            else if(other.GetComponent<Movement>().transform.position.x > transform.position.x)
//            {
//                resumedXVelocity = XVELOCITY ;
//                transform.Translate(other.GetComponent<Movement>().transform.position.x-transform.position.x-other.GetComponent<Movement>().transform.localScale.x,0,velocity.z);
//            }
//            else
//            {
//                SceneManager.LoadScene(0);
//            }
//
//            
//            velocity.x = 0f;
//            velocity.z = other.GetComponent<Movement>().speed;
//
//        }
//
//
//        gameController.GetComponent<Score>().score +=1;
//        
//        GameObject effect = Instantiate(impact, other.ClosestPoint(transform.position), transform.rotation);
//        Vector3 dir = transform.position - other.ClosestPoint(transform.position);
//        effect.transform.rotation = Quaternion.LookRotation(dir);
//        var emptyObject = new GameObject();
//        emptyObject.transform.parent = other.transform;
//        effect.transform.parent = emptyObject.transform;
//        Destroy(effect, 1.5f);
//        
//
//        for (int i = 0; i < 10; i++)
//        {
//            GameObject blueEffect = Instantiate(blueImpact, other.ClosestPoint(transform.position), transform.rotation);
//            Vector3 dir2 = transform.position - other.ClosestPoint(transform.position);
//            blueEffect.transform.rotation = Quaternion.LookRotation(dir2);
//            var emptyObject2 = new GameObject();
//            emptyObject2.transform.parent = other.transform;
//            blueEffect.transform.parent = emptyObject2.transform;
//            Destroy(blueEffect, 1.5f);
//        }
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






//            Vector3 explosionPos = transform.position;
//            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
//            
//            
//            foreach (Collider hit in colliders)
//            {
//                
//                Rigidbody rb = hit.GetComponent<Rigidbody>();
//
//                if (rb != null)
//                {
//                    
//                    rb.AddExplosionForce(power, explosionPos, radius, 0);
//                }
//            }