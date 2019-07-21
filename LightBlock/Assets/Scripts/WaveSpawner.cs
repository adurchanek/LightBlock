using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    
    public GameObject brickPrefab;
    public float viewport = .5625f;
    

    
    
    public int numBricks;
    //public Transform enemyPrefab;

    //public Wave[] waves;


    public float timeBetweenWaves = 5f;

    //private float countdown = 2f;

    private int waveIndex = 0;

    //public Transform spawnPoint;

    //public Text countdownText;

    public float spawnSpeed = .15f;

    public void Start()

    {
        numBricks = 0;

        
        
        //float newWidth = Screen.width;
        //Vector2 v = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        
        //Vector2 v = Camera.main.ScreenToViewportPoint(new Vector3(0,0, 0));
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(0,0,0));
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 9));
        float distance;
        xy.Raycast(ray, out distance);
        Vector3 v = ray.GetPoint(distance);
        

        top.transform.localScale = new Vector3(top.transform.localScale.x*(Camera.main.aspect/viewport), top.transform.localScale.y, top.transform.localScale.z);
        bottom.transform.localScale = new Vector3(bottom.transform.localScale.x*(Camera.main.aspect/viewport), bottom.transform.localScale.y, bottom.transform.localScale.z);
    }


    private void Update()
    {
        
        //top.transform.localScale = new Vector3(top.transform.localScale.x*(Camera.main.aspect/viewport), top.transform.localScale.y, top.transform.localScale.z);
        //bottom.transform.localScale = new Vector3(top.transform.localScale.x*(Camera.main.aspect/viewport), bottom.transform.localScale.y, bottom.transform.localScale.z);

        if (Input.GetMouseButtonDown(0))
        {
            
            //public Vector3 ScreenToWorldPoint(Vector3 position);
            
            //Vector2 v = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
            //Debug.Log(GetWorldPositionOnPlane(new Vector3(0,0,0),9));
            
            //Debug.Log(Camera.main.aspect);
            //Debug.Log(Camera.main.aspect/viewport);
            
            //top.transform.localScale = new Vector3(top.transform.localScale.x*(Camera.main.aspect/viewport), top.transform.localScale.y, top.transform.localScale.z);
            //bottom.transform.localScale = new Vector3(top.transform.localScale.x*(Camera.main.aspect/viewport), bottom.transform.localScale.y, bottom.transform.localScale.z);

        }



        if (numBricks < 2)

        {
            
            StartCoroutine(SpawnWave());
        }

//        if (enemiesAlive > 0)
//
//        {
//            return;
//        }
//
//        if (countdown <= 0f)
//        {
//            StartCoroutine(SpawnWave());
//            countdown = timeBetweenWaves;
//            return;
//
//        }
//		
//        countdown -= Time.deltaTime;
//		
//        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
//        countdownText.text = string.Format("{0:0.0}",countdown);
//		
//        
    }

//    IEnumerator SpawnWave()
//    {
//        PlayerStats.rounds += 1;
//
//        Wave wave = waves[waveIndex];
//
//        for (int i = 0; i < wave.count; i++)
//        {
//            SpawnEnemy(wave.enemy);  
//            
//            yield return new WaitForSeconds(1f/wave.rate);
//        }
//
//        waveIndex += 1;
//
//        if (waveIndex == waves.Length)
//
//        {
//			
//            Debug.Log("Level won");
//            enabled = false;
//
//        }
//
//        //EnemyMovement.speed += spawnSpeed;
//    }


    IEnumerator SpawnWave()
    {
        //PlayerStats.rounds += 1;

        //Wave wave = waves[waveIndex];

        //for (int i = 0; i < 100000000000000; i++) //TODO change to while loop
        while(true)
        {
            SpawnBrick(brickPrefab);
            float r = Random.Range(.5f, 2f);
            numBricks += 1;
            yield return new WaitForSeconds(r);
        }

        



        //EnemyMovement.speed += spawnSpeed;
    }

    private void SpawnBrick(GameObject brick)
    {


        float r = Random.Range(0f, 1f);
        //float width = Random.Range(0, top.transform.localScale.x);
        
        float width = Random.Range(2, (int)(top.transform.localScale.x/brickPrefab.transform.localScale.x));
        
        //Debug.Log(brickPrefab.transform.localScale.x);
        
        
        if (r < .5)
        {
            Vector3 pos = new Vector3(top.transform.position.x - top.transform.localScale.x/2 + width*brickPrefab.transform.localScale.x,top.transform.position.y, top.transform.position.z);
            GameObject go = Instantiate(brick, pos, top.transform.rotation);
            Movement movement = go.GetComponent<Movement>();
            if (movement != null)

            {
                movement.initialize("Top",top, -1);
			
            }
            
        }
        else
        {
            
            //Debug.Log(r);
            Vector3 pos = new Vector3(bottom.transform.position.x - bottom.transform.localScale.x/2 + width*brickPrefab.transform.localScale.x,bottom.transform.position.y, bottom.transform.position.z);
            //Vector3 pos = new Vector3(bottom.transform.position.x - bottom.transform.localScale.x/2+width,bottom.transform.position.y, bottom.transform.position.z);
            GameObject go = Instantiate(brick, pos, bottom.transform.rotation);
            Movement movement = go.GetComponent<Movement>();
            
            if (movement != null)

            {
                movement.initialize("Bottom",bottom, 1);
			
            }

        }
        

        numBricks += 1;
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
    
}
