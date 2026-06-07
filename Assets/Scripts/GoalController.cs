using UnityEngine;

public class GoalController : MonoBehaviour
{
    private bool faseConcluida = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (faseConcluida)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            faseConcluida = true;

            GameManager gameManager = FindAnyObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.ConcluirFase();
            }
        }
    }
}