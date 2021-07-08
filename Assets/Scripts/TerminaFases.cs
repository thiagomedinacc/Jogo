using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminaFases : MonoBehaviour
{
    // Start is called before the first frame update
     public bool fase1, fase2, fase3;

     public Image img;
     public Text t;

     
    void Start()
    {
        img.enabled = false;
        t.enabled = false;
        


        fase1 = false;
        fase2 = false;
        fase3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (fase1 && fase2 && fase3){
         //   img.enabled = true;
          //  t.enabled = true;
         //   StartCoroutine(waiter());
            
      //  }
    }

    //IEnumerator waiter()
//{
    
    //Wait for 4 seconds
   // yield return new WaitForSeconds(2);
   // Time.timeScale = 0;
    
//}

   public void  venceFase1(){
            img.enabled = true;
            t.enabled = true;
    }
    public void  venceFase2(){
            img.enabled = true;
            t.enabled = true;
    }
    public void  venceFase3(){
            img.enabled = true;
            t.enabled = true;
    }
}
