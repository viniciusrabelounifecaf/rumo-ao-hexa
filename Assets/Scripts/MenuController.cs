using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [Header("Configuração")]
    public string nomePrimeiraFase = "Fase01_Campinho";

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Jogar();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Sair();
        }
    }

    public void Jogar()
    {
        if (string.IsNullOrWhiteSpace(nomePrimeiraFase))
        {
            Debug.Log("Nenhuma fase inicial configurada.");
            return;
        }

        SceneManager.LoadScene(nomePrimeiraFase);
    }

    public void Sair()
    {
        Debug.Log("Saindo do jogo.");

        Application.Quit();
    }
}