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
    }
// Update is called once per frame
    void Update()
    {

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