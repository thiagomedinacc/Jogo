using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControle : MonoBehaviour
{

    float potencia = 4f;
    float torque = 4f;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Acelera")){
            //
            //Debug.Log("Acelera");
            rb.AddForce(transform.up * potencia);

            rb.AddTorque(Input.GetAxis("Horizontal") * torque);
        } 
    
        
    }
}
