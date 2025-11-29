using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class Asteroides : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //Função para destruir asteroides fora de cena
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pontoDestroi"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
