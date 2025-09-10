using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class CuttableBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Image Image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("FNScore", PlayerPrefs.GetInt("FNScore", 0) + 1);
        }
    }

    public void SetText(string text)
    {
        textMeshProUGUI.enabled = true;
        textMeshProUGUI.text = text;
    }

    public void SetImage(Sprite sprite)
    {
        Image.enabled = true;
        Image.sprite = sprite;
    }
}
