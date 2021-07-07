using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControle : MonoBehaviour
{

    private int qtdNitro = 1;
    public float potencia = 12f;
    public float handling = -100f;
    public float aceleracao = 0.004f;
    public float velMax;

    bool inercia = true;
    bool inerciaRe = true;

    public float velocidade = 0.1f;

    public float marchaRe = 0.1f;

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

       if (Input.GetKey("space")) { // Controles de freio
            inerciaRe = false;
             if (marchaRe < velMax){
               marchaRe += aceleracao;
            }
            rb.AddForce(transform.up * potencia * (marchaRe/-2f) );
          
        }

        rb.velocity = ForwardVelocity() + RightVelocity() * 0.5f; // Para nao deslizar
        

        if (Input.GetButton("Acelera")){
           // audio.Play();
            inercia = false;
            rb.drag = 1;
            if (velocidade < velMax){
               velocidade += aceleracao;
            }
            rb.AddForce(transform.up * potencia * (velocidade));
        }
        if (Input.GetButtonUp("Acelera")) {
            inercia = true;
            rb.drag = 1.3f;
        }
        

        if (velocidade > 0.1f & inercia) {
               velocidade -= 0.01f; // fator de volta a velocidade minima
            }
        
        if (marchaRe > 0.1f & inerciaRe) {
            marchaRe -= 0.01f; // fator de volta a velocidade minima (da marcha ré)
        }
       
        if (rb.velocity.magnitude >= 0.3f){
            rb.angularVelocity = Input.GetAxis("Horizontal") * handling;
        } 
    }


    // Funcoes para ajudar no drift
    Vector2 ForwardVelocity(){
        return transform.up * Vector2.Dot(rb.velocity,transform.up);
    }
     Vector2 RightVelocity(){
        return transform.right * Vector2.Dot(rb.velocity,transform.right);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Nitro") {
            qtdNitro +=1;
        }
        
    }

}
