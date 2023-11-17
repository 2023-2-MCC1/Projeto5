using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas

public class LoseGame : MonoBehaviour
{

    public void Start()
    {
        //Para destravar o mouse, devido a configuração de outro script.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackToMenu(){
        //Redirecionando para a primeira cena do jogo
        SceneManager.LoadScene(0);
    }
}
