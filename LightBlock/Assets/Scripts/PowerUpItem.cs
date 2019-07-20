


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;


public enum PowerUpItemType
{
    
    
    none,
    currency,
    increaseSize,
    decreaseSize,
    brickHitAoe
}

[System.Serializable]
public class ItemDefinition
{
    public PowerUpItemType type = PowerUpItemType.none;
    public string letter;
    public Color color = Color.white;
    public int value;
    public float sizeChange;
    public float brickHitAoeRadius;






}



public class PowerUpItem : MonoBehaviour
{

    
    
    
}

