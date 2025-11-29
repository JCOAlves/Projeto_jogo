using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelasFundo : MonoBehaviour
{
    //SCRIPT PARA AS ESTRELAS NO FUNDO DO JOGO
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pontoDestroi"))
        {
            Debug.Log("Estrelas destruidas.");
            Destroy(gameObject);
        }
    }
}
