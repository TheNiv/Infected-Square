using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Sprite player;
    public GameObject[] Sprites; //The sprites to spawn (Prefabs).
    private int rand; // A random number to determine which sprite to spawn.
    public float spawnInterval; //The number of seconds between each spawn at the current score.
    private float nextSpawnTime;  // Will the next spawn time (Time.time + spawnInterval)
    private float[] probabilities = new float[] { 0.5f, 0.5f }; //The probabilities to spawn each sprite. index 0-Medicine,index 1-Virus.
    private Vector2 screenBounds;
    void Start()
    {

        Vector3 randPos = CreateValidRandomPos();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        //Spawn the collectable at a random coordinate.
        
        Instantiate(Sprites[0], randPos, Quaternion.identity);
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    void Spawn()
    {
        
        //boundries of screen
       
        //Creating a random position
        
        //Use probabilities to choose which sprite to spawn.
        rand = Random.Range(0, 101);  
        if (rand <= probabilities[0] * 100) //Generate medicine 
        {
            Instantiate(Sprites[0], CreateValidRandomPos(), Quaternion.identity);
        }
        else//Generate Virus
        {
            Instantiate(Sprites[1], CreateValidRandomPos(), Quaternion.identity);
        }
    }
    Vector3 CreateValidRandomPos()
    {
        bool done = false;
        Vector3 randpos= new Vector3();
        while (!done)
        {
            randpos= new Vector3(Random.Range(-1 * Screen.width, Screen.width), Random.Range(-1 * Screen.height, Screen.height), 1);
            if (player.bounds.Contains(randpos))
            {
                done = true;
            }
        }
        return randpos;
    }
}
