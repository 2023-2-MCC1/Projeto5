using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas

public class MainMenuManager : MonoBehaviour
{
    public GameObject MenuPanel;      // Painel do menu principal
    public GameObject ConfigPanel;    // Painel do menu de configurações
    public GameObject HowToPlayPanel; // Painel do menu de como jogar
    
    /* Acionado quando clicarmos em "Jogar" */
    public void Play(){
        Debug.Log("Abrindo o jogo...");
        SceneManager.LoadScene(1);
        /*
            SceneManager.LoadScene(1)
            Podemos passar uma string com o nome do cenário
            ou o índice da cena! 
        */
    }

    /* Acionado quando clicarmos em "configurações" */
    public void OpenConfig(){
        MenuPanel.SetActive(false); //desativa o menu principal
        ConfigPanel.SetActive(true);//ativa o menu de configurações
    }

    public void CloseConfig(){
        ConfigPanel.SetActive(false);//desativa o menu de configurações
        MenuPanel.SetActive(true); //ativa o menu principal
    }

    /* Acionado quando clicarmos em "como jogar" */
    public void OpenHowToPlay(){
        HowToPlayPanel.SetActive(true); //ativa o menu de como jogar
        MenuPanel.SetActive(false);     //desativa o menu principal
    }

    public void CloseHowToPlay(){
        HowToPlayPanel.SetActive(false); //desativa o menu de como jogar
        MenuPanel.SetActive(true);      //ativa o menu principal
    }

    /* Acionado ao clicarmos em "sair" */
    public void QuitGame(){
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Fecha o jogo
    }
}
