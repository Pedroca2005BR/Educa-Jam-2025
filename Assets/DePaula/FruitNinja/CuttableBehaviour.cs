using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class CuttableBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Image Image;
    public bool correctAnswer = false;

    Animator animator;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
            boxCollider.enabled = false;

            if (correctAnswer)
            {
                //ScoreManager.instance.score++;
                ScoreManager.instance.ScoreUp();
                animator.SetTrigger("CorrectHit");
            }
            else
            {
                animator.SetTrigger("WrongHit");
                ScoreManager.instance.LoseLife();
            }
        }
        else if (collision.gameObject.CompareTag("Destroyer"))
        {
            if (correctAnswer)
            {
                ScoreManager.instance.LoseLife();
            }

            Destroy(gameObject);
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

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
