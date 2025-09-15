using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int gateValue; // valor da porta, será a resposta
    public bool isCorrect; // se é a resposta certa
    [SerializeField] TextMeshProUGUI textComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isCorrect)
                Debug.Log("Acertou!");
            else
                Debug.Log("Errou!");

            // depois de passar, opcionalmente destrói o portão
            Destroy(gameObject);
        }
    }

    public void Setup(int gateValue, bool isCorrect)
    {
        this.gateValue = gateValue;
        this.isCorrect = isCorrect;

        textComponent.text = gateValue.ToString();
    }
}
