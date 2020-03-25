using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public int fireRate;  //the max number of projectiles that can be shot per second.
    private float lastFired;  //the time the last projectile has been spawned. To make sure projectiles are not shot too fast.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time -lastFired > 1f/fireRate)  //check if enough time has passed so it does not shoot too fast.
            {

                lastFired = Time.time;
                GameObject p = Instantiate(projectile, this.transform.position, Quaternion.identity);  //spawn projectile
                 

            }
            
        }
    }
}
