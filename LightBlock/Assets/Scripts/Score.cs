using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int hitNumScore;
    public int highScore;

    public Text scoreText;
    public Text highScoreText;

    public GameObject player;
    private Player playerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        
        //Debug.Log("start: " + playerScript.hitNumScore);
        scoreText.text = hitNumScore.ToString();
        highScoreText.text = playerScript.highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //hitNumScore = playerScript.hitNumScore;
        scoreText.text = playerScript.hitNumScore.ToString();
        
        //highScore = playerScript.highScore;
        highScoreText.text = playerScript.highScore.ToString();
        
    }
    
    //TODO let game run on mac vs phone. the amount of bricks is much higher. time.delta time issue?
}