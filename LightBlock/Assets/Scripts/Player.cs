using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int hitNumScore;
    public int highScore;
    private PlayerMovement playerMovement;
    
    
    private void Awake()
    {
        hitNumScore = 0;
        LoadPlayer();
        
        Debug.Log("highscore: " + highScore);
        playerMovement = GetComponent<PlayerMovement>();

    }
    
    public void SavePlayer()
    {
        if (hitNumScore > highScore)
        {
            SaveManager.SavePlayer(this);
        }


    }
    
    public void LoadPlayer()
    {
        
        PlayerData data = SaveManager.LoadPlayer();

        if (data == null)
        {
            
            //TODO initialize fresh
            highScore = 0;
        }
        else
        {
            highScore = data.highScore;
        }
        
    }
    
    
    public void AbsorbPowerUp(GameObject go)
    {

        PowerUp pu = go.GetComponent<PowerUp>();

        switch (pu.type)
        {
            case PowerUpItemType.currency:
                Debug.Log("currency powerup absorbed. do something");
                break;
            case PowerUpItemType.brickHitAoe:
                Debug.Log("AOE powerup absorbed. do something");
                break;
            default:
                break;
            
        }

        pu.AbsorbedBy(this.gameObject);
    }
    
    
    
}