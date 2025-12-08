using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float deslocamentoX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Movimentacao()
    {
        
        //Adiciona deslocamento vertical
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

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
}
