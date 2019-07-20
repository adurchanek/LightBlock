using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    public string location;

    public GameObject end;

    public float speed;
    public int direction;
    
    Collider m_ObjectCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        
        float r = Random.Range(0.01f, .05f);
        //speed *= r;
        float size = Random.Range(-.5f, .5f);
        speed *= (.005f+(size+.5f)/20);

        //transform.localScale.z *= size;
        float sizeVar = transform.localScale.z * size;
        
        transform.localScale += new Vector3(0, 0, sizeVar);

//        if (direction == 1)
//        {
//            transform.localScale += new Vector3(.001f, 0, 0);
//        }
//        else
//        {
//            transform.localScale += new Vector3(-.001f, 0, 0); //TODO add child collider
//        }

        

//        //Fetch the GameObject's Collider (make sure they have a Collider component)
//        m_ObjectCollider = GetComponent<Collider>();
//        //Here the GameObject's Collider is not a trigger
//        m_ObjectCollider.isTrigger = true;
//        //Output whether the Collider is a trigger type Collider or not
//        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0,0,speed);
        
        
        
        
        //speed += 1;


    }


    public void initialize(string l, GameObject t, int d)

    {

        this.speed = 1f;
        this.location = l;
        this.end = t;

        this.direction = d;

        speed *= d; //TODO both todos and lighting dgu
        

        //TODO make two on side that constantly go up or down? random? left and right? 
        //TODO the faster the brick is going, the faster the ball repels off it

    }

    void setDirection()
    {
        
        
    }
    
    
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Top"))
//        {
//            Debug.Log("top");
//        }
//        else if (other.CompareTag("Top"))
//
//        {
//            
//            Debug.Log("bottom");
//        }
//    }
    
    
}







/*
 *
 *
 *
 *
 *
 
 
 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    public string location;

    public GameObject end;

    public float speed;
    public int direction;
    
    Collider m_ObjectCollider;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
        float r = Random.Range(0.01f, .05f);
        //speed *= r;
        float size = Random.Range(-.5f, .5f);
        speed *= (.005f+(size+.5f)/20);

        //transform.localScale.z *= size;
        float sizeVar = transform.localScale.z * size;
        
        transform.localScale += new Vector3(0, 0, sizeVar);

        rb = GetComponent<Rigidbody>();

//        //Fetch the GameObject's Collider (make sure they have a Collider component)
//        m_ObjectCollider = GetComponent<Collider>();
//        //Here the GameObject's Collider is not a trigger
//        m_ObjectCollider.isTrigger = true;
//        //Output whether the Collider is a trigger type Collider or not
//        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //rb.Translate(0,0,speed);
        
        //rb.MovePosition(new Vector3(0,0,speed));
        
        rb.MovePosition(transform.position + new Vector3(0,0,speed) * Time.deltaTime);
        
        
        
        
        //speed += 1;


    }


    public void initialize(string l, GameObject t, int d)

    {

        this.speed = 100f;
        //this.speed = 1f;
        this.location = l;
        this.end = t;

        this.direction = d;

        speed *= d; //TODO both todos and lighting dgu
        

        //TODO make two on side that constantly go up or down? random? left and right? 
        //TODO the faster the brick is going, the faster the ball repels off it

    }

    void setDirection()
    {
        
        
    }
    
    
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Top"))
//        {
//            Debug.Log("top");
//        }
//        else if (other.CompareTag("Top"))
//
//        {
//            
//            Debug.Log("bottom");
//        }
//    }
    
    
}

 
 
 
 
 */
