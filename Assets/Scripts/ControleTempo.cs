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
    public Text scoreT;

    public Text bonus;
    public int score;
    
    //private Vector3 posInicial;

    public GameObject fases;
   
    private int faseAtual;

    bool upgrade1;
    bool upgrade2;
    bool upgrade3;

    int qtdUpgrades;

    //public Transform car;

   

    
    // Start is called before the first frame update
    void Start()
    {
        upgrade1 = false; 
        upgrade2 = false; 
        upgrade3 = false;
        qtdUpgrades = 0;
       // posInicial =  new Vector3 (car.transform.position.x, car.transform.position.y, car.transform.position.z);//

        scoreT.text = "Score:" + score.ToString() + "g/10";
        score = 0;
        inicioVolta = true; // Se true, então está dando a volta
        tempoVolta = 0f;
        verificaRes = false;
        tempoAux = 0f;
        if (SceneManager.GetActiveScene().name == "Fase 1"){
            tempoAlvo = 15f;
            tempoA.text = "Tempo Alvo: 15s";
            faseAtual = 1;  
        }
        else if (SceneManager.GetActiveScene().name == "Fase 2" ){
            tempoAlvo = 30f;
            tempoA.text = "Tempo Alvo: 30s"; 
            faseAtual = 2;  
        }
        else {
            tempoAlvo = 35f;
            tempoA.text = "Tempo Alvo: 35s"; 
            faseAtual = 3;  
        }
             
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
                if (faseAtual == 1) {
                    fases.GetComponent<TerminaFases>().venceFase1();  
                }
                if (faseAtual == 2) {
                    fases.GetComponent<TerminaFases>().venceFase2();  
                }
                else {
                    fases.GetComponent<TerminaFases>().venceFase3();
                }
            }
            else {
                //print ("Tente novamente!! Sua volta foi" + tempoFinal + " segundos");    
                tempoV.text =("Tente novamente!! Sua volta foi de                   " + tempoFinal + " segundos");
                score +=10;
                scoreT.text = "Score:" + score.ToString() + "g/10";
                if(score == 10 && qtdUpgrades <3) {
                    score = 0;
                    scoreT.text = "Score:" + score.ToString() + "g/10";
                    qtdUpgrades++;
                    bool ok = false;
                while (!ok){         
                        int rand = Random.Range(1, 4);
                        print(rand);
                        if (rand == 1 && upgrade1 == false) {
                            bonus.text = "Motor v8 instalado. Aumento de velocidade máxima";
                            upgrade1 = true;
                            ok = true;
                        }
                        if (rand == 2  && upgrade2 == false) {
                            bonus.text = "Turbo instalado. Aumento de aceleração";
                            upgrade2 = true;
                            ok = true;
                        }
                        if (rand == 3 && upgrade3 == false) {
                            bonus.text = "Pneus slick instalados. Aumento de handling";
                            upgrade3 = true;
                            ok = true;
                        }

                    }
                  
                   // 
                }


               // car.transform.position = posInicial;
               // car.transform.rotation.z = 90f;
               // car.
                //transform.position.x = -86f;
                }

            verificaRes = false;            
        }

        if (Input.GetButton("Retry")){

        // Start();
          SceneManager.LoadScene("Fases");
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
