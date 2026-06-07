using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Pontuação")]
    public int pontos = 0;
    public int coletaveisPegos = 0;

    [Header("Vidas")]
    public int vidas = 3;

    [Header("Referências")]
    public HUDController hudController;
    public Transform player;
    public Transform pontoInicial;
    public GameObject painelGameOver;
    public GameObject painelFaseConcluida;

    [Header("Transição de Fase")]
    public string nomeProximaFase;

    [Header("Áudio")]
    public AudioSource audioSource;
    public AudioClip somColetarMedalha;
    public AudioClip somDano;
    public AudioClip somGameOver;
    public AudioClip somFaseConcluida;

    private bool jogoAcabou = false;
    private bool faseConcluida = false;

    private void Start()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(false);
        }

        if (painelFaseConcluida != null)
        {
            painelFaseConcluida.SetActive(false);
        }

        AtualizarInterface();
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SairDoJogo();
        }

        if (jogoAcabou && Keyboard.current.rKey.wasPressedThisFrame)
        {
            ReiniciarFase();
        }

        if (faseConcluida)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                ReiniciarFase();
            }

            if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                CarregarProximaFase();
            }
        }
    }

    public bool JogoAcabou()
    {
        return jogoAcabou;
    }

    public bool FaseConcluida()
    {
        return faseConcluida;
    }

    public bool JogadorBloqueado()
    {
        return jogoAcabou || faseConcluida;
    }

    public void AdicionarPonto(int valor)
    {
        if (JogadorBloqueado())
        {
            return;
        }

        pontos += valor;
        coletaveisPegos++;

        TocarSom(somColetarMedalha);

        Debug.Log("Pontos: " + pontos + " | Medalhas: " + coletaveisPegos);

        AtualizarInterface();
    }

    public void ReceberDano()
    {
        if (JogadorBloqueado())
        {
            return;
        }

        vidas--;

        Debug.Log("Tomou dano! Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            GameOver();
            return;
        }

        TocarSom(somDano);

        ReposicionarPlayer();
        AtualizarInterface();
    }

    public void ConcluirFase()
    {
        if (JogadorBloqueado())
        {
            return;
        }

        faseConcluida = true;

        if (painelFaseConcluida != null)
        {
            painelFaseConcluida.SetActive(true);
        }

        TocarSom(somFaseConcluida);

        PararPlayer();
        AtualizarInterface();

        Debug.Log("Fase concluída!");
    }

    private void ReposicionarPlayer()
    {
        if (player != null && pontoInicial != null)
        {
            player.position = pontoInicial.position;
            PararPlayer();
        }
    }

    private void PararPlayer()
    {
        if (player != null)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }

    private void GameOver()
    {
        jogoAcabou = true;
        vidas = 0;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }

        TocarSom(somGameOver);

        PararPlayer();
        AtualizarInterface();

        Debug.Log("Game Over!");
    }

    private void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CarregarProximaFase()
    {
        if (string.IsNullOrWhiteSpace(nomeProximaFase))
        {
            Debug.Log("Nenhuma próxima fase configurada.");
            return;
        }

        SceneManager.LoadScene(nomeProximaFase);
    }

    private void SairDoJogo()
    {
        Debug.Log("Saindo do jogo.");

        Application.Quit();
    }

    private void AtualizarInterface()
    {
        if (hudController != null)
        {
            hudController.AtualizarHUD(pontos, coletaveisPegos, vidas);
        }
    }

    private void TocarSom(AudioClip som)
    {
        if (audioSource != null && som != null)
        {
            audioSource.PlayOneShot(som);
        }
    }
}