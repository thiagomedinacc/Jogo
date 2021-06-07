using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraJogo : MonoBehaviour
{
    public Transform carro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(carro.position.x, carro.position.y, -10f);
    }
}
