using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    private Vector2 screenBounds;
    private Rigidbody2D rb;
    
    
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log(screenBounds.x);
        Debug.Log(screenBounds.y);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.right * speed * Time.deltaTime;
        
        if(this.transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
            
    }

}
