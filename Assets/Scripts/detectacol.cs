using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectacol : MonoBehaviour
{
   AudioSource audioData;    
         void OnCollisionEnter2D(Collision2D collision) //Detecta colisao nos muros
    
{

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Carro")
        {
            //audioData.Play(); nao funcionou
            
            
        }
    }
    }

