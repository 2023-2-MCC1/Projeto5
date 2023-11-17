using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAnimation : MonoBehaviour
{
    public GameObject cilinder;     //Referência para o nosso bastão
    private bool isMoving = false; //Controla se o objeto está em movimento
    private float scroll;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            // Mova o objeto uma unidade para a frente
            transform.Translate(Vector3.forward, Space.Self);
            isMoving = true;

             // Inicia uma corrotina para retornar o objeto à sua posição original após um atraso de 0.2 segundos.
            StartCoroutine(ReturnObjectAfterDelay(0.2f));
        }
    }

    IEnumerator ReturnObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Movendo o objeto uma unidade para trás, para dar a sensação de ataque
        transform.Translate(-Vector3.forward, Space.Self);

        isMoving = false; //quando terminar o delay, o player poderá atacar novamente
    }
}
