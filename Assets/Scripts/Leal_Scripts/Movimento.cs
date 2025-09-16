using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
//using UnityEngine.InputSystem.EnhancedTouch;

public class Movimento : MonoBehaviour
{
    //public float velocidadePlayer = 1;
    //public float velocidadeHorizontal = 3;
    //public float limiteDireito = 4f;
    //public float limiteEsquerdo = 4f;


    //void UpdateDeprecated()
    //{
    //    transform.Translate(Vector3.forward * Time.deltaTime * velocidadePlayer, Space.World);

    //    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (this.gameObject.transform.position.x > (limiteEsquerdo * -1))
    //        {
    //            transform.Translate(Vector3.left * Time.deltaTime * velocidadeHorizontal);
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    //    {
    //        if (this.gameObject.transform.position.x < limiteDireito)
    //        {
    //            transform.Translate(Vector3.right * Time.deltaTime * velocidadeHorizontal);
    //        }
    //    }
    //}


    private Touch touch;
    public float sidewaysSpeed = 5f;
    public float forwardSpeed = 10f;
    public float minX, maxX;
    Vector3 target;

    void Start()
    {
        Input.multiTouchEnabled = false;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, forwardSpeed));

            // Força o Y ser igual ao do transform
            worldPoint.y = transform.position.y;

            // Aplica limites
            //worldPoint.x = Mathf.Clamp(worldPoint.x, minX, maxX);

            target = worldPoint;



        }
        else
        {
            target = new Vector3(
                Mathf.Clamp(transform.position.x, minX, maxX), // aplica limite no movimento automático também
                transform.position.y,
                transform.position.z + forwardSpeed
            );
        }

        //transform.Translate(Vector3.MoveTowards(transform.position, target, sidewaysSpeed * Time.deltaTime) - transform.position);

        Vector3 nextPos = Vector3.MoveTowards(
            transform.position,
            target,
            sidewaysSpeed * Time.deltaTime
            );

        // aplica limite manualmente aqui também
        nextPos.x = Mathf.Clamp(nextPos.x, minX, maxX);

        transform.position = nextPos;


    }
}
