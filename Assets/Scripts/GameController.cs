using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pontoAsteroides, pontoDestroi;
    [SerializeField] private GameObject mensagemInicial, botaoStart, setasIndicativas;
    [SerializeField] private GameObject AsteroideVerde, AsteroideAmarelo, AsteroideVermelho, Pontuacao;
    [SerializeField] public Text TextoPontuacao;
    private int Pontos;
    public static GameController instance;
    private bool started;
    [SerializeField] private float intervalo;
    [SerializeField] private int Loop;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroi outras instacias com Gamecontroller. Só pode haver um objeto GameController.
            CancelInvoke("Asteroides");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        IniciacaoJogo();
        ReniciacaoJogo();
    }
    private void IniciacaoJogo()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !started)
        {
            if (mensagemInicial.activeSelf && botaoStart.activeSelf && setasIndicativas.activeSelf) //activeSelf verifica se o objeto estar na cena.
            {
                mensagemInicial.SetActive(false); //Retira o elemento da cena, mas não o destroi
                botaoStart.SetActive(false);
                setasIndicativas.SetActive(false);
                Pontuacao.SetActive(true);
            }
            Pontos = 0;
            TextoPontuacao.text = Pontos.ToString();
            started = true;
            Debug.Log("Foguete Estelar Iniciado!");


            //InvokeRepeating([nome da função entre aspas], [tempo em segundos para começar a função], [intevalo de repetição em segundos]);
            InvokeRepeating("Asteroides", 1f, intervalo);
        }

    }

    //Resolver o problema da reiniciação do jogo
    public void ReniciacaoJogo()
    {
        if (!started && Input.GetKeyDown(KeyCode.R))
        {
            started = true;
            //IniciacaoJogo();
        }
    }

    public void ContagemPontos(int Ponts)
    {
        Pontos += Ponts;
        if (Pontos < 0) { Pontos = 0; }
        TextoPontuacao.text = Pontos.ToString();
    }

    private void Asteroides()
    {
        List<string> listaAsteroides = new List<string> { "Verde", "Verde", "Amarelo", "Amarelo", "Vermelho", "Vermelho" };
        int posicaoAsteroide = Random.Range(0, 6);
        string AsteroideEscolhido = listaAsteroides[posicaoAsteroide];
        float posicaoX;
        float posicaoY = pontoAsteroides.transform.position.y;
        //intervalo = intervalo - 0.1f;

        switch (AsteroideEscolhido)
        {
            case "Verde":
                for (int X = 0; X < Loop; X++)
                {
                    posicaoX = Random.Range(-4.5f, 4.5f);
                    posicaoY += 5 * X;
                    Instantiate(
                        AsteroideVerde, //Instancia do asteroide
                        new Vector2(posicaoX, posicaoY), //Na posição (posicaoX, posicaoY)
                        Quaternion.identity  //Com rotação padrão (sem rotação, identidade)
                    );
                }
                break;
            case "Amarelo":
                for (int X = 0; X < Loop; X++)
                {
                    posicaoX = Random.Range(-4.5f, 4.5f);
                    posicaoY += 5 * X;
                    Instantiate(
                        AsteroideAmarelo,
                        new Vector2(posicaoX, posicaoY),
                        Quaternion.identity
                    );
                }
                break;
            case "Vermelho":
                for (int X = 0; X < Loop; X++)
                {
                    posicaoX = Random.Range(-4.5f, 4.5f);
                    posicaoY += 5 * X;
                    Instantiate(
                        AsteroideVermelho,
                        new Vector2(posicaoX, posicaoY),
                        Quaternion.identity
                    );
                }
                break;
        }
    }

    public void SetStarted(bool started)
    {
        this.started = started;
    }

    public bool GetStarted()
    {
        return started;
    }
}