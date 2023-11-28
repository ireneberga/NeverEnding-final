using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Rigidbody dragon;

   // private Vector3 force = new Vector3(0, 0, 1000);
    
    private bool moveLeft;
    private bool moveRight;
    // Start is called before the first frame update
    // void Start()
    // {
    //     dragon.AddForce(force);
    // }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
    }
    
    private void FixedUpdate()
    {
        dragon.AddForce(0,0,400 * Time.deltaTime);
        
        if(moveLeft)
        {
            dragon.AddForce(-300 * Time.deltaTime, 0, 0);
        }
        
        if (moveRight)
        {
            dragon.AddForce(300 * Time.deltaTime, 0, 0);
        }
    }
   
}
