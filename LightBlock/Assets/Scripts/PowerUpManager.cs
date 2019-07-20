


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour


{
    
    //public GameObject drop;
    //public  int numDrops;
    public ItemDefinition[] itemDefinitions;
    static Dictionary<PowerUpItemType, ItemDefinition> itemDict;
    
    // Start is called before the first frame update
    void Awake()
    {
        //numDrops = 0;
        
        itemDict = new Dictionary<PowerUpItemType, ItemDefinition>();

        foreach (ItemDefinition def in itemDefinitions)
        {
            itemDict[def.type] = def;
        }


        //StartCoroutine(SpawnDrops());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public ItemDefinition GetItemDefinition(PowerUpItemType itemType)
    {


        if (itemDict.ContainsKey(itemType))
        {

            return itemDict[itemType];
        }

        return (new ItemDefinition());
    }












































/*

    IEnumerator SpawnDrops()
    {
        //PlayerStats.rounds += 1;

        //Wave wave = waves[waveIndex];

        //for (int i = 0; i < 100000000000000; i++) //TODO change to while loop
        while(true)
        {
            SpawnDrop(drop);
            float r = Random.Range(.5f, 2f);
            numDrops += 1;
            yield return new WaitForSeconds(r);
        }

        



        //EnemyMovement.speed += spawnSpeed;
    }
    
    
    */
    

    private void SpawnDrop(GameObject drop)
    {
        
        /*
        //TODO height and width for random spawn points
        float r = Random.Range(0f, 1f);
        //float width = Random.Range(0, top.transform.localScale.x);
        
        float width = Random.Range(2, (int)(top.transform.localScale.x/brickPrefab.transform.localScale.x));

        
        Vector3 pos = new Vector3(bottom.transform.position.x - bottom.transform.localScale.x/2 + width*brickPrefab.transform.localScale.x,bottom.transform.position.y, bottom.transform.position.z);
        //Vector3 pos = new Vector3(bottom.transform.position.x - bottom.transform.localScale.x/2+width,bottom.transform.position.y, bottom.transform.position.z);
        GameObject go = Instantiate(drop, pos, bottom.transform.rotation);
        Movement movement = go.GetComponent<Movement>();
            
        if (movement != null)

        {
            movement.initialize("Bottom",bottom, 1);
			
        }
        
        */
    }



}

