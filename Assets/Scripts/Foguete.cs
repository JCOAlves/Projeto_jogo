using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete : MonoBehaviour
{
    [SerializeField] private float deslocamentoX;
    [SerializeField] private GameObject GameOver, reniciar, pontuacao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Movimentacao()
    {
        
        //Movimentação do Foguete
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float direita = transform.position.x + deslocamentoX;
            if (direita > 4.5f) { direita = 4.5f; }
            transform.position = new Vector2(
                direita,
                transform.position.y
            );
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            float esquerda = transform.position.x - deslocamentoX;
            if (esquerda < -4.5f){ esquerda = -4.5f; }
            transform.position = new Vector2(
                esquerda,
                transform.position.y
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AsteroideVerde"))
        {
            GameController.instance.ContagemPontos(10);
            Destroy(other.gameObject);
            Debug.Log("Asteroide Verde destruido");
        }
        else if (other.CompareTag("AsteroideAmarelo"))
        {
            GameController.instance.ContagemPontos(1);
            Destroy(other.gameObject);
            Debug.Log("Asteroide Amarelo destruido");
        }
        else if (other.CompareTag("AsteroideVermelho"))
        {
            Debug.Log("GAME OVER");
            if (!GameOver.activeSelf && !reniciar.activeSelf && pontuacao.activeSelf)
            {
                GameOver.SetActive(true);
                reniciar.SetActive(true);
                pontuacao.SetActive(false);
            }

            GameController.instance.SetStarted(false);
            Time.timeScale = 0f; //Paraliza o jogo.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance != null && GameController.instance.GetStarted() && Time.timeScale != 0f)
        {
            Movimentacao();
        }
    }
}
