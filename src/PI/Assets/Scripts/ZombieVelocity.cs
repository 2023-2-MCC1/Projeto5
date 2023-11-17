using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVelocity : MonoBehaviour
{
    public float speed;
    private ZombieController zombieController;

    void Start(){
        /* 
            Quando nascer no lado oposto do mapa, rotaciona o zumbi para ele 
            não correr de "costas"
        */
        if (transform.position.z < 0){
            RotateZombie();
        }
    }

    void Update()
    {   
        /* Todo zumbi que spawnar, irá andar reto em direção ao centro da vila */
        if(transform.position.z > 0)
            transform.position += Vector3.forward * speed * Time.deltaTime;
        else {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
        }
    }

    void RotateZombie()
    {
        // Obtém a rotação atual do objeto
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Adiciona 180 graus ao eixo Y
        currentRotation.y += 180f;

        // Aplica a nova rotação ao objeto
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    void OnTriggerEnter(Collider collision){
        Debug.Log("Flechada no zumbi");
        zombieController = FindObjectOfType<ZombieController>();
        /* Retorna true quando o zumbi morre, e assim destroi o objeto */
        bool killed = zombieController.VerifyHit(true);
        if(killed){
            Debug.Log("Entrou ");
            killed = false;
            Destroy(gameObject);
        }
    } 
}
