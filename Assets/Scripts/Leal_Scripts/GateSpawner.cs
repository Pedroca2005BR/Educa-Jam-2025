using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GameObject leftGatePrefab;   // Prefab do portão da esquerda
    public GameObject rightGatePrefab;  // Prefab do portão da direita
    public float gateOffsetX = 3f;      // Distância lateral entre os portões

    public void SpawnGateAt(Vector3 position, Transform parentTile) // agora recebe o tile como parent
    {
        // Spawn portão da esquerda
        if (leftGatePrefab != null)
        {
            Vector3 leftPos = position + Vector3.left * gateOffsetX;
            GameObject leftGate = Instantiate(leftGatePrefab, leftPos, Quaternion.identity);
            leftGate.transform.parent = parentTile; // define o tile como pai
        }

        // Spawn portão da direita
        if (rightGatePrefab != null)
        {
            Vector3 rightPos = position + Vector3.right * gateOffsetX;
            GameObject rightGate = Instantiate(rightGatePrefab, rightPos, Quaternion.identity);
            rightGate.transform.parent = parentTile; // define o tile como pai
        }
    }
}
