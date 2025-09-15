using UnityEngine;

public class AsteroidControler : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _velocidade;
    private Collider2D _collider;
    /// <summary>
    /// TO DO:
    /// Adicionar uma animacao quando a municao encostar no lixo, ou encostar no caminhao
    /// </summary>
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForceY(-_velocidade, ForceMode2D.Impulse);
        _collider = GetComponentInChildren<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("aaaaaaaaaaaa");
        _collider.enabled = false;
        //Destroy(collision.transform.parent.gameObject);
        Destroy(gameObject);
    }
}
