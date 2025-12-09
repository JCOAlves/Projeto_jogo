using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float deslocamentoX;
    [SerializeField] private float deslocamentoY;

    private SpriteRenderer sprite;
    private Animator animator;
    private Vector2 normal_size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        normal_size = transform.localScale;
    }

    private RaycastHit2D RaycastTo(Vector2 origin, Vector2 destination)
    {
        Vector2 direction = (destination - origin).normalized;
        Debug.DrawRay(origin, direction, Color.magenta);
        return Physics2D.Raycast(origin, direction, 1);
    }
    
    private void Movimentacao()
    {
        
        //Adiciona deslocamento vertical
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = normal_size;
            animator.SetBool("Descendo", false);
            animator.SetBool("Subindo", false);
            animator.SetBool("Andando", true);
            sprite.flipX = true;
            float posicao = transform.position.x + deslocamentoX;
            RaycastHit2D hit = RaycastTo(transform.position,
                transform.position + new Vector3(deslocamentoX, 0f, 0f));
            if (!(hit && hit.collider.CompareTag("Wall")))
            {
                if (posicao > 4.5f)
                {
                    if (Mathf.Abs(transform.position.y - (-0.1f)) < 0.001)
                    {
                        posicao = -3.8f;
                    }
                    else
                    {
                        posicao = 4.2f;

                    }
                }
            }
            else
            {
                posicao = transform.position.x;
            }

            transform.position = new Vector2(
                posicao,
                transform.position.y
            );
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = normal_size;
            animator.SetBool("Descendo", false);
            animator.SetBool("Subindo", false);
            animator.SetBool("Andando", true);
            sprite.flipX = false;
            float posicao = transform.position.x - deslocamentoX;
            RaycastHit2D hit = RaycastTo(transform.position,
                transform.position - new Vector3(deslocamentoX, 0f, 0f));
            if (hit)
            {
                System.Console.WriteLine("AAAAAA WHAT THE F&CK " + hit.collider.tag);
            }
            if (!(hit && hit.collider.CompareTag("Wall")))
            {
                if (posicao < -4.5f)
                {
                    if (Mathf.Abs(transform.position.y - (-0.1f)) < 0.001)
                    {
                        posicao = 4.2f;
                    }
                    else
                    {
                        posicao = -3.8f;

                    }
                }
            }
            else
            {
                posicao = transform.position.x;
            }

            transform.position = new Vector2(
                posicao,
                transform.position.y
            );
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale = normal_size;
            animator.SetBool("Descendo", false);
            animator.SetBool("Subindo", true);
            animator.SetBool("Andando", false);
            float posicao = transform.position.y + deslocamentoY;
            RaycastHit2D hit = RaycastTo(transform.position,
                transform.position + new Vector3(0f, deslocamentoY, 0f));
            if (!(hit && hit.collider.CompareTag("Wall"))) {
                if (posicao > 3.9f)
                {
                    if (Mathf.Abs(transform.position.x - 0.2f) < 0.001)
                    {
                        posicao = -4.1f;
                    }
                    else
                    {
                        posicao = 3.9f;

                    }
                }
            }
            else
            {
                posicao = transform.position.y;
            }

            transform.position = new Vector2(
                transform.position.x,
                posicao
            );
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = normal_size * 0.8f;
            animator.SetBool("Descendo", true);
            animator.SetBool("Subindo", false);
            animator.SetBool("Andando", false);
            float posicao = transform.position.y - deslocamentoY;
            RaycastHit2D hit = RaycastTo(transform.position,
                transform.position - new Vector3(0f, deslocamentoY, 0f));
            if (!(hit && hit.collider.CompareTag("Wall")))
            {
                if (posicao < -4.1f)
                {
                    if (Mathf.Abs(transform.position.x - 0.2f) < 0.001)
                    {
                        posicao = 3.9f;
                    }
                    else
                    {
                        posicao = -4.1f;

                    }
                }
            }
            else
            {
                posicao = transform.position.y;
            }

            transform.position = new Vector2(
                transform.position.x,
                posicao
            );
        }

    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
}
