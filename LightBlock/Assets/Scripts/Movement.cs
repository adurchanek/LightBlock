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
        float size = Random.Range(-.5f, .5f);
        speed *= (.005f+(size+.5f)/20);
        float sizeVar = transform.localScale.z * size;
        transform.localScale += new Vector3(0, 0, sizeVar);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed);
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
}





