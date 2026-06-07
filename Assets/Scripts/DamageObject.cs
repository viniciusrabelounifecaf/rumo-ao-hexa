using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private bool causandoDano = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (causandoDano)
        {
            return;
        }

        if (collision.collider.CompareTag("Player"))
        {
            causandoDano = true;

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
        causandoDano = false;
    }
}