// using UnityEngine;


// public class GateSpawner : MonoBehaviour
// {
//     public QuestionManager questionManager;
//     public GameObject leftGatePrefab;   // Prefab do portão da esquerda
//     public GameObject rightGatePrefab;  // Prefab do portão da direita
//     public float gateOffsetX = 3f;      // Distância lateral entre os portões

//     // public void SpawnGateAt(Vector3 position, Transform parentTile) // agora recebe o tile como parent
//     // {
//     //     // Spawn portão da esquerda
//     //     if (leftGatePrefab != null)
//     //     {
//     //         Vector3 leftPos = position + Vector3.left * gateOffsetX;
//     //         GameObject leftGate = Instantiate(leftGatePrefab, leftPos, Quaternion.identity);
//     //         leftGate.transform.parent = parentTile; // define o tile como pai
//     //     }

//     //     // Spawn portão da direita
//     //     if (rightGatePrefab != null)
//     //     {
//     //         Vector3 rightPos = position + Vector3.right * gateOffsetX;
//     //         GameObject rightGate = Instantiate(rightGatePrefab, rightPos, Quaternion.identity);
//     //         rightGate.transform.parent = parentTile; // define o tile como pai
//     //     }
//     // }
//     public void SpawnGateAt(Vector3 position, Transform parentTile)
//     {
//         if (questionManager == null) return;

//         MathQuestion q = questionManager.GetRandomQuestion();
//         int correct = q.correctAnswer;
//         int wrong = questionManager.GetWrongAnswer(correct);

//         bool leftIsCorrect = Random.value > 0.5f;

//         // Spawn esquerda
//         GameObject leftGate = Instantiate(leftGatePrefab, position + Vector3.left * gateOffsetX, Quaternion.identity, parentTile);
//         Gate leftGateScript = leftGate.GetComponent<Gate>();
//         if (leftGateScript != null)
//         {
//             leftGateScript.gateValue = leftIsCorrect ? correct : wrong;
//             leftGateScript.isCorrect = leftIsCorrect;
//         }

//         // Spawn direita
//         GameObject rightGate = Instantiate(rightGatePrefab, position + Vector3.right * gateOffsetX, Quaternion.identity, parentTile);
//         Gate rightGateScript = rightGate.GetComponent<Gate>();
//         if (rightGateScript != null)
//         {
//             rightGateScript.gateValue = leftIsCorrect ? wrong : correct;
//             rightGateScript.isCorrect = !leftIsCorrect;
//         }

//         Debug.Log($"Pergunta: {q.question}, esquerda: {leftGateScript.gateValue}, direita: {rightGateScript.gateValue}");
//     }
// }
using UnityEngine;
using TMPro; // Se usar TextMeshPro para mostrar a pergunta

public class GateSpawner : MonoBehaviour
{
    [Header("Portões")]
    public GameObject gatePrefab;
    //public GameObject rightGatePrefab;
    public float gateOffsetX = 3f;

    [Header("Perguntas")]
    public QuestionManager questionManager; // Pode deixar vazio que será preenchido automaticamente
    //public TMP_Text questionText; // Texto no Canvas para mostrar a pergunta
    public GameObject questionHolderPrefab;

    void Start()
    {
        // Se não foi arrastado no Inspector, pega automaticamente o QuestionManager no mesmo objeto
        if (questionManager == null)
            questionManager = GetComponent<QuestionManager>();
    }

    public void SpawnGateAt(Vector3 position, Transform parentTile)
    {
        if (questionManager == null || questionManager.questions.Length == 0)
        {
            Debug.LogWarning("QuestionManager vazio ou sem perguntas!");
            return;
        }

        // Pega uma pergunta aleatória
        MathQuestion q = questionManager.GetRandomQuestion();

        // Gera o texto de pergunta
        GameObject questionHold = Instantiate(questionHolderPrefab, position + Vector3.up * gateOffsetX, Quaternion.identity, parentTile);
        questionHold.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = q.question;
        

        int correct = q.correctAnswer;
        int wrong = questionManager.GetWrongAnswer(correct);

        bool leftIsCorrect = Random.value > 0.5f;

        // Spawn portão esquerdo
        GameObject leftGate = Instantiate(gatePrefab, position + Vector3.left * gateOffsetX, Quaternion.identity, parentTile);
        Gate leftGateScript = leftGate.GetComponent<Gate>();
        if (leftGateScript != null)
        {
            leftGateScript.Setup(leftIsCorrect ? correct : wrong, leftIsCorrect);
            //leftGateScript.gateValue = leftIsCorrect ? correct : wrong;
            //leftGateScript.isCorrect = leftIsCorrect;
        }

        // Spawn portão direito
        GameObject rightGate = Instantiate(gatePrefab, position + Vector3.right * gateOffsetX, Quaternion.identity, parentTile);
        Gate rightGateScript = rightGate.GetComponent<Gate>();
        if (rightGateScript != null)
        {
            rightGateScript.Setup(leftIsCorrect ? wrong : correct, !leftIsCorrect);
            //rightGateScript.gateValue = leftIsCorrect ? wrong : correct;
            //rightGateScript.isCorrect = !leftIsCorrect;
        }

        Debug.Log($"Pergunta: {q.question}, esquerda: {leftGateScript.gateValue}, direita: {rightGateScript.gateValue}");
    }
}
