using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GameObject leftGatePrefab;   // Prefab do portão da esquerda
    public GameObject rightGatePrefab;  // Prefab do portão da direita
    public float gateOffsetX = 3f;      // Distância lateral entre os portões

    public void SpawnGateAt(Vector3 position)
    {
        // Spawn portão da esquerda
        if (leftGatePrefab != null)
        {
            Vector3 leftPos = position + Vector3.left * gateOffsetX;
            Instantiate(leftGatePrefab, leftPos, Quaternion.identity);
        }

        // Spawn portão da direita
        if (rightGatePrefab != null)
        {
            Vector3 rightPos = position + Vector3.right * gateOffsetX;
            Instantiate(rightGatePrefab, rightPos, Quaternion.identity);
        }
    }
}
