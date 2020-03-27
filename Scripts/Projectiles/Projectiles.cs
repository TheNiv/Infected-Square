using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    private Vector2 screenBounds;
    private Rigidbody2D rb;
    private Vector2 direction;


    void Start()
    {   
       //transform.position += transform.right * speed * Time.deltaTime;
        rb = this.GetComponent<Rigidbody2D>();
        Vector3 mousePos = Input.mousePosition;  //getting the mouse position.
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //trasnforming the mouse position to a point in the world.
        direction = new Vector2(mousePos.x, mousePos.y);  //getting the point direction.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //the angle to rotate the projectile to.  
        transform.rotation = Quaternion.Euler(0, 0, angle); // rotate the projectile to the target point.
        direction.Normalize();
        float distance = direction.magnitude;
        direction = direction / distance ;
        Ray2D ray = new Ray2D(this.transform.position, direction);  //the ray of the projectile target
        rb.velocity =  speed * new Vector2(ray.direction.x, ray.direction.y); //setting the projectile movement direction
        //Debug.Log(ray.direction);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > screenBounds.x || this.transform.position.x < screenBounds.x *-1) //making sure the object does not pass the edge of the screen
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
            ShootProjectile.virusesDestroyed++;
        }
            
    }

}
