using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas
using UnityEngine.UI;

public class LifeVillage : MonoBehaviour
{   
    private int lifeRemains = 100;
    private ZombieController zombieController;

     public Slider slider;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {   
        /* Toda vez que a colisão for um objeto com a tag zombie, irá diminuir a vida da vila em 5 pontos! */
        if (collision.gameObject.tag == "zombie")
        {
            lifeRemains -= 5;
            slider.value = lifeRemains;

            Destroy(collision.gameObject);
            
            /* Caso a vida restante seja 0, ele perderá o jogo! */
            if (lifeRemains == 0 || lifeRemains < 0)
            {
                EndGame();
            }

            zombieController = FindObjectOfType<ZombieController>();
            zombieController.VerifyHit(false, 100);
        } else if (collision.gameObject.tag == "Giant")
        {
            EndGame();
        }
    }  

    /* Se a vida da vila chegar em zero, ele irá para a cena de quem perdeu o jogo :D */
    private void EndGame(){
        Debug.Log("Perdeu o jogo D: ");
        SceneManager.LoadScene(2);
    }  
}
