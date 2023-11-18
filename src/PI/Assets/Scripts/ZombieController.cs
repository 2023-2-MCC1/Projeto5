using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    public GameObject zombie;
    public GameObject giant;
    public float range;

    private int hitsToDestory = 0;
    private int hitsToDestroyGiant = 0;
    public Text zombiesLeft, timerText, monsterText;
    public GameObject uiTimer;
    public Image uiFill; //Temporizador visual

    private int zombiesLeftNumber;
    /* Ajustando o temporizador entre as rodadas! */
    private float Timer = 15f;
    private bool TimeController = true;

    private int round = 1;
    private bool canAtack = true;

    /* Round no lado positivo do mapa (coordenada z positiva) */
    void RoundX(int zombiesNumber){
        for (int i = 0; i < zombiesNumber; i++)
        {
            GameObject newZombie = Instantiate(zombie);
            newZombie.transform.position = transform.position + new Vector3(Random.Range(-range, range), 0, Random.Range(-10, 10));
        }
    }

    /* Round no lado negativo do mapa (coordenada z positiva) */
    void RoundY(int zombiesNumber){

        for (int i = 0; i < zombiesNumber; i++)
        {
            GameObject newZombie = Instantiate(zombie);
            newZombie.transform.position = new Vector3(Random.Range(-range, range), 0, Random.Range(-60, -70)); //Para nascer do outro lado do mapa
        }
    }

    void FinalRound()
    {
        GameObject newGiant = Instantiate(giant);
    }

    // Update is called once per frame
    void Update()
    {   
        if (TimeController){
            TimeUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canAtack = !canAtack;
        }
        if (Input.GetMouseButtonDown(0) && canAtack)
        {
            Camera PlayerCam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            float maxRayLength = 5f;
            RaycastHit hit;
                    
            /* Verificação para saber se o player está perto o suficiente para poder Matar o zumbi */
            if (Physics.Raycast(ray, out hit, maxRayLength))
            {
            /* Aqui ficará responsável por detectar caso o usuário clique em cima do zumbi  */
                if (hit.collider.gameObject.tag == "zombie")
                { 
                    bool matar = VerifyHit(false);
                    /* Vai retornar true quando o contador de hits chegar em 6 */
                    if (matar){
                        Destroy(hit.collider.gameObject);
                    }
                } else if (hit.collider.gameObject.tag == "Giant")
                {
                    Debug.Log("Hit no gigante");
                    hitsToDestroyGiant++;

                    if (hitsToDestroyGiant == 100) {
                        Destroy(hit.collider.gameObject);
                        Debug.Log("Venceu!");
                    }
                }

            }
        }
    }

    void TimeUpdate(){
        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f0");
        uiFill.fillAmount = Mathf.InverseLerp(0, 15, Timer);
        /* Devemos converter o timer para um int para poder comparar */
        if (Mathf.RoundToInt(Timer) == 0){
            
            /* Controle para evitar que o tempo se altere durante a rodada */
            uiTimer.SetActive(false);
            TimeController = false; 

            switch (round)
            {
                case 1:
                    /* Parametro -> número de zumbis que vao nascer */
                    RoundX(5);
                    zombiesLeftNumber = 5;
                    zombiesLeft.text = zombiesLeftNumber.ToString();
                    break;
                case 2:
                    RoundY(10);
                    zombiesLeftNumber = 10;
                    zombiesLeft.text = zombiesLeftNumber.ToString();
                    break; 
                case 3:
                    RoundX(15);
                    zombiesLeftNumber = 15;
                    zombiesLeft.text = zombiesLeftNumber.ToString();
                    break;
                case 4:
                    RoundY(20);
                    zombiesLeftNumber = 20;
                    zombiesLeft.text = zombiesLeftNumber.ToString();
                    break;
                case 5:
                    FinalRound();
                    zombiesLeftNumber = 1;
                    monsterText.text = "Gigante";
                    zombiesLeft.text = "";
                    break;
            }

        }
    }

    /* 
        Essa função verifica se o hit foi do bastão ou do arco, quando o zumbi é 
        atingido pelo arco, leva mais dano em comparação ao bastão
    */
    public bool VerifyHit(bool arrow, int test = 0){
        if (arrow == true && test == 0){
            hitsToDestory += 3; //quando atingido pelo arco
        } else if (arrow == false && test == 0) {
            hitsToDestory++; //atingido pelo bastão
        } else {
            hitsToDestory = 6;
        }

        if (hitsToDestory == 6)
        {
            hitsToDestory = 0;
            zombiesLeftNumber--;
            zombiesLeft.text = zombiesLeftNumber.ToString();

            if (zombiesLeftNumber == 0)
            {
                round++;
                Timer = 15f;
                TimeController = true;
                uiTimer.SetActive(true);
            } 
            return true;
        }
        return false;
    }
}