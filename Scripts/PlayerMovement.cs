using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The input for at the horizontal axis - Keys A and D.
        float horizontalIInput = Input.GetAxis("Horizontal");// gets a value of 1 or -1 (right or left)
        transform.Translate(new Vector3(horizontalIInput, 0, 0)*speed*Time.deltaTime);
        // The input for at the vertical axis - Keys W and S.
        float verticalInput = Input.GetAxis("Vertical");// gets a value of 1 or -1 (up or down)
        transform.Translate(new Vector3(0, verticalInput, 0) * speed * Time.deltaTime);
    }
}
