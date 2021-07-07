using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleTempo : MonoBehaviour
{
    public float tempoAlvo;
    private bool inicioVolta;

    private float tempoVolta;
    private bool verificaRes ;

    private float tempoInicioVolta ;

    private float tempoAux;


    public Text tempoV;
    public Text tempoA;
    

    
    // Start is called before the first frame update
    void Start()
    {
         tempoA.text = "Tempo Alvo: 15s";
        inicioVolta = true; // Se true, então está dando a volta
        tempoVolta = 0f;
        verificaRes = false;
        tempoAux = 0f;
        if (SceneManager.GetActiveScene().name == "Fase 1"){
            tempoAlvo = 15f;  
        }
        else if (SceneManager.GetActiveScene().name == "Fase 2" ){
            tempoAlvo = 30f;
        }
        else tempoAlvo = 35f;
             
    }

    // Update is called once per frame
    void Update()    {
       
        
         tempoAux = Time.time;

        if (inicioVolta == false) {       
            tempoVolta = Time.time ;
            tempoV.text = "Tempo atual de volta: "+ (tempoVolta - tempoInicioVolta);
        }

        if (verificaRes == true ) {
            inicioVolta = true;
            float tempoFinal = tempoVolta - tempoInicioVolta;
            if (tempoFinal < tempoAlvo) {
                //print ("Parabens!! Sua volta foi de" + tempoFinal + " segundos");
                tempoV.text = ("Parabens!! Sua volta foi de" + tempoFinal + " segundos");
            }
            else {
                //print ("Tente novamente!! Sua volta foi" + tempoFinal + " segundos");    
                tempoV.text =("Tente novamente!! Sua volta foi de                   " + tempoFinal + " segundos");
                }

            verificaRes = false;            
        }

        if (Input.GetButton("Retry")){

         Start();
          SceneManager.LoadScene("Cena2D");
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "Carro" & inicioVolta) {
            tempoInicioVolta = Time.time;
            inicioVolta = false;                   
        }
        else if (col.gameObject.tag == "Carro" & inicioVolta == false & tempoAux > 5f) {
            verificaRes = true;         
        }
    }

    }
