using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float velocidadeCorrida = 8f;
    public float velocidadeNoAr = 4.5f;
    public float forcaPulo = 6f;

    [Header("Verificação de Chão")]
    public float distanciaVerificacaoChao = 0.45f;
    public float raioVerificacao = 0.2f;
    public LayerMask camadaChao;

    private Rigidbody2D rb;
    private GameManager gameManager;

    private float movimentoHorizontal;
    private bool estaNoChao;
    private bool querPular;
    private bool estaCorrendo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (gameManager != null && gameManager.JogadorBloqueado())
        {
            movimentoHorizontal = 0f;
            querPular = false;
            return;
        }

        VerificarChao();
        LerEntradaDoJogador();
        GirarBolaVisualmente();
    }

    void FixedUpdate()
    {
        if (gameManager != null && gameManager.JogadorBloqueado())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Mover();
        Pular();
    }

    void LerEntradaDoJogador()
    {
        movimentoHorizontal = 0f;
        estaCorrendo = false;

        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movimentoHorizontal = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movimentoHorizontal = 1f;
        }

        if (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed)
        {
            estaCorrendo = true;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            querPular = true;
        }
    }

    void Mover()
    {
        float velocidadeAtual;

        if (estaNoChao)
        {
            velocidadeAtual = estaCorrendo ? velocidadeCorrida : velocidade;
        }
        else
        {
            velocidadeAtual = velocidadeNoAr;
        }

        rb.linearVelocity = new Vector2(
            movimentoHorizontal * velocidadeAtual,
            rb.linearVelocity.y
        );
    }

    void Pular()
    {
        if (querPular)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            querPular = false;
        }
    }

    void VerificarChao()
    {
        Vector2 pontoVerificacao = (Vector2)transform.position + Vector2.down * distanciaVerificacaoChao;

        estaNoChao = Physics2D.OverlapCircle(
            pontoVerificacao,
            raioVerificacao,
            camadaChao
        );
    }

    void GirarBolaVisualmente()
    {
        if (Mathf.Abs(movimentoHorizontal) > 0.01f && estaNoChao)
        {
            float direcaoGiro = movimentoHorizontal > 0 ? -1f : 1f;
            transform.Rotate(0f, 0f, direcaoGiro * 300f * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 pontoVerificacao = (Vector2)transform.position + Vector2.down * distanciaVerificacaoChao;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pontoVerificacao, raioVerificacao);
    }
}