using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private bool danoAplicado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (danoAplicado)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            danoAplicado = true;

            GameManager gameManager = FindAnyObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.ReceberDano();
            }

            Invoke(nameof(LiberarDano), 0.5f);
        }
    }

    private void LiberarDano()
    {
        danoAplicado = false;
    }
}