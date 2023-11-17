using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas

public class PauseGame : MonoBehaviour
{   
    private bool jogoPausado = false;
    public GameObject menuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if (jogoPausado)
            {
                // Se o jogo já estiver pausado, retoma o tempo
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                menuPause.SetActive(false);
            }
            else
            {
                // Se o jogo não estiver pausado, pausa o tempo
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                menuPause.SetActive(true);
            }

            // Inverte o estado de pausa
            jogoPausado = !jogoPausado;
        }
    }

    public void backToMenu(){
        SceneManager.LoadScene(0);
    }

}
