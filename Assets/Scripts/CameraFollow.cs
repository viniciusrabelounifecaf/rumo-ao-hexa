using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Alvo da Câmera")]
    public Transform alvo;

    [Header("Configurações de Seguimento")]
    public float suavidade = 5f;
    public Vector3 deslocamento = new Vector3(2f, 1f, -10f);

    [Header("Limites da Câmera")]
    public bool usarLimites = false;
    public float limiteMinX;
    public float limiteMaxX;
    public float limiteMinY;
    public float limiteMaxY;

    void LateUpdate()
    {
        if (alvo == null)
        {
            return;
        }

        Vector3 posicaoDesejada = alvo.position + deslocamento;

        if (usarLimites)
        {
            posicaoDesejada.x = Mathf.Clamp(posicaoDesejada.x, limiteMinX, limiteMaxX);
            posicaoDesejada.y = Mathf.Clamp(posicaoDesejada.y, limiteMinY, limiteMaxY);
        }

        transform.position = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            suavidade * Time.deltaTime
        );
    }
}