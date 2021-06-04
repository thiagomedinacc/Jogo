using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControle : MonoBehaviour
{

    public float potencia = 12f;
    public float handling = -100f;
    public float aceleracao = 0.004f;
    public float velMax;

    bool inercia = true;

    public float velocidade = 0.7f;

    Rigidbody2D rb;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velMax = potencia/10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if (Input.GetKey("space")) { // Controles de drift.
        //    rb.velocity = RightVelocity()/2 + ForwardVelocity()*1.5f; //+ ForwardVelocity();
       // }

        rb.velocity = ForwardVelocity() + RightVelocity() * 0.5f; // Para nao deslizar

        if (Input.GetButton("Acelera")){
            inercia = false;
            rb.drag = 1;
            if (velocidade < velMax){
               velocidade += aceleracao;
            }
            rb.AddForce(transform.up * potencia * (velocidade));
        }
        if (Input.GetButtonUp("Acelera")) {
            inercia = true;
            rb.drag = 1.7f;
        }
        if (velocidade > 0.7f & inercia) {
            velocidade -= 0.02f; // fator de volta a velocidade minima
        }

       // Vector2 parado = new Vector2(0.01f, 0.01f);
        if (rb.velocity.magnitude >= 0.2f){
            rb.angularVelocity = Input.GetAxis("Horizontal") * handling;
        }
        //}

        
    }



    // Funcoes para ajudar no drift
    Vector2 ForwardVelocity(){
        return transform.up * Vector2.Dot(rb.velocity,transform.up);
    }
     Vector2 RightVelocity(){
        return transform.right * Vector2.Dot(rb.velocity,transform.right);
    }
}
