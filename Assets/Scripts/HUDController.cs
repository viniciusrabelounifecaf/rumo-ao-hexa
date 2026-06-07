using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [Header("Textos do HUD")]
    public TMP_Text textoPontos;
    public TMP_Text textoColetaveis;
    public TMP_Text textoVidas;

    [Header("Configuração")]
    public int totalColetaveis = 3;

    public void AtualizarHUD(int pontos, int coletaveisPegos, int vidas)
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontos;
        }

        if (textoColetaveis != null)
        {
            textoColetaveis.text = "Medalhas: " + coletaveisPegos + "/" + totalColetaveis;
        }

        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }
}