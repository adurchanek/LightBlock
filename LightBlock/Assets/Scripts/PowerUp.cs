


using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    
    
    [Header("Set in Inspector")]
    public Vector2 rotMinMax = new Vector2(15,90);
    public Vector2 driftMinMax = new Vector2(.12f,.25f);
    public float lifeTime = 6f;
    public float fadeTime = 4f;
    
    [Header("Set Dynamically")]
    public PowerUpItemType type;
    public GameObject cube;
    public TextMesh letter;
    public Vector3 rotPerSecond;
    public float birthTime;

    private Rigidbody rigid;
    //private BoundsCheck bndCheck;
    private Renderer cubeRend;
    public Vector3 positionOffset;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        cube = transform.Find("Cube").gameObject;
        letter = GetComponent<TextMesh>();
        rigid = GetComponent<Rigidbody>();
        //bndCheck = GetComponent<BoundsCheck>();
        cubeRend = GetComponent<Renderer>();

        Vector3 vel = Random.onUnitSphere;
        vel.y = 0;
        vel.Normalize();
        vel *= Random.Range(driftMinMax.x, driftMinMax.y);
        rigid.velocity = vel/7;
        transform.rotation = Quaternion.identity;
        
        rotPerSecond = new Vector3(Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y),Random.Range(rotMinMax.x, rotMinMax.y) );
        birthTime = Time.time;
    }

    private void Start()
    {
        //transform.position.y = positionOffset.y;
        transform.position = new Vector3(transform.position.x,positionOffset.y,transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.rotation = Quaternion.Euler(rotPerSecond * Time.time);
        float u = (Time.time - (birthTime + lifeTime)) / fadeTime;
        if (u >= 1)
        {
            Destroy(this.gameObject);
            return;
        }

        if (u > 0)
        {
            Color c = cubeRend.material.color;
            c.a = 1f - u;
            cubeRend.material.color = c;
            c = letter.color;
            c.a = 1f - (u * 0.5f);
            letter.color = c;
        }
        
        letter.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
 
        letter.transform.rotation = Quaternion.Euler(-.5f*rotPerSecond * Time.time);




        //if (!bndCheck.isOnScreen)
        //{
        //Destroy(gameObject);

        //}
    }


    
    public void SetType(PowerUpItemType wt)
    {

        ItemDefinition def = PowerUpManager.GetItemDefinition(wt);
        cubeRend.material.color = def.color;
        letter.text = def.letter;
        type = wt;
    }
    
    
    
    public void AbsorbedBy(GameObject target)
    {
        Destroy(this.gameObject);
    }



}
