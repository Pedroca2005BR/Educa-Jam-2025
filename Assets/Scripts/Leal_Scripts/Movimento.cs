using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimento : MonoBehaviour
{
    public float velocidadePlayer = 1;
    public float velocidadeHorizontal = 3;
    public float limiteDireito = 4f;
    public float limiteEsquerdo = 4f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidadePlayer, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > (limiteEsquerdo * -1))
            {
                transform.Translate(Vector3.left * Time.deltaTime * velocidadeHorizontal);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < limiteDireito)
            {
                transform.Translate(Vector3.right * Time.deltaTime * velocidadeHorizontal);
            }
        }
    }
}
