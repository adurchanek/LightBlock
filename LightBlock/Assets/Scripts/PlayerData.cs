using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlayerData
{
    public int highScore;


    public PlayerData(Player p )

    {
        highScore = p.hitNumScore;

    }
    
}