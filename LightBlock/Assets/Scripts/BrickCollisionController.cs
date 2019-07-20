using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollisionController : MonoBehaviour
{
    
    
    //public GameObject top;
    //public GameObject bottom;

    private string location;

    
    // Start is called before the first frame update
    void Start()
    {
        location = "";
            
        Movement movement = GetComponent<Movement>();
        if (movement != null)
        {
            this.location = movement.location;
        }


    }
    
    // Start is called before the first frame update
    void Awake()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("ENTERED!!!!");
        if (location == "")
        {
            location = GetComponent<Movement>().location;
        }
        if(location == "Top")
        {
            if (other.CompareTag("Top"))
            {
                //Debug.Log("IGNORE");
            }
            else if (other.CompareTag("Bottom"))

            {

                //Debug.Log("DESTROY");
                Destroy(gameObject);
            }
        }
        else
        {
            
            if (other.CompareTag("Top"))
            {
                //Debug.Log("DESTROY");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Bottom"))

            {

                //Debug.Log("IGNORE");
            }

        }
    }
    
    
}