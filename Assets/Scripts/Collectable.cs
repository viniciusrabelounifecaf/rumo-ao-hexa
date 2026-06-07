using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Configuração do Coletável")]
    public int valor = 1;

    private bool coletado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coletado)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            coletado = true;

            GameManager gameManager = FindAnyObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.AdicionarPonto(valor);
            }

            Destroy(gameObject);
        }
    }
}