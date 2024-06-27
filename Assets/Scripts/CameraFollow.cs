using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;  // Referência ao Transform do jogador
    public float offsetX = 0f;         // Offset no eixo X entre a câmera e o jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento

    void LateUpdate()
    {
        // Posição desejada da câmera
        Vector3 desiredPosition = new Vector3(playerTransform.position.x + offsetX, transform.position.y, transform.position.z);
        // Suaviza a transição entre a posição atual e a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}
