using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Rigidbody dragon;

    private Vector3 force = new Vector3(0, 0, 500);
    // Start is called before the first frame update
    void Start()
    {
        dragon.AddForce(force);
    }

    // Update is called once per frame
   
}
