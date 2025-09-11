using UnityEngine;

public class Municao : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _velocidade;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb.AddForceY(_velocidade, ForceMode2D.Impulse);
    }
}
