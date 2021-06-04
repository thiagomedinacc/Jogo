using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePneu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right")) {
            transform.Rotate(0,0,-30);
        }
         if (Input.GetKey("right")) {
            transform.Rotate(0,0,30);
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right") ){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }
}
