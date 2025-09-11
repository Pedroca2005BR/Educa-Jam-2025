using UnityEngine;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{
    Rigidbody2D _rb;
    // gerar o manipulador de direcao em Y
    private float _yDir;
    [SerializeField] float ySpeed;
    // gerar o manipulador de direcao em X
    private float _xDir;
    [SerializeField] float xSpeed;
    // gerando a fabrica de municao
    [SerializeField] GameObject municaoPrefab;
    [SerializeField] Transform arma;
    [SerializeField] float vida;
    
    // gerar manipuladores de tiro
    private bool _taTirano;
    [SerializeField] float _fireRate;
    private float lastShot;
    void Awake()
    {
        lastShot = Time.time;
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_taTirano)
            Atirar();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movimentar();
    }
    // Método para modificar a velocidade do corpo Rigido
    void Movimentar()
    {
        _rb.linearVelocityY = _yDir * ySpeed * Time.deltaTime;
        _rb.linearVelocityX = _xDir * xSpeed * Time.deltaTime;
    }
    // Métodos para identificar o Movimento
    void OnMove(InputValue inputValue)
    {
        _yDir = inputValue.Get<Vector2>().y;
        _xDir = inputValue.Get<Vector2>().x;
    }
    // Métodos para controlar o Tiro
    void OnAttack(InputValue inputValue)
    {
        _taTirano = inputValue.isPressed;
    }
    void Atirar()
    {
        if (Time.time - lastShot > _fireRate)
        {
            // Criar munições
            Instantiate(municaoPrefab, arma.position, Quaternion.identity);
            lastShot = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Incostou");
    }
}
