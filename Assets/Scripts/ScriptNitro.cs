using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNitro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        Destroy(gameObject, 0.3f);
    }
}
