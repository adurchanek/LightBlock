using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    //Brick class
    public Shader shader;
    public Texture texture;
    public Color color;
    
    public float hue;
    public float saturation;
    public float brightness;

    private Renderer rend;
    
    private int numTimesHit;
    
    
    void Start()
    {

        numTimesHit = 0;
        rend = GetComponent<Renderer>();

        brightness = 1;
        saturation = 1;
        hue = 1;



//rend.material.color = Color.HSVToRGB(.1f, .1f, .1f);

//rend.material = new Material(shader);
//rend.material.mainTexture = texture;
//rend.material.color = color;

    }
// Update is called once per frame
    void Update()
    {
        
        //transform.Translate(0,0,.01f);
        
        //rend.material.color = Color.HSVToRGB(hue, saturation, brightness);
        
        //rend.material. = Color.HSVToRGB(hue, saturation, brightness);
        if( hue >= 1f )
            hue = 0f;
        else
        {
            hue = hue + .002f;
        }
        
    }


    public void SetColor()
    {
        rend.material.color = Color.red;

    }



}