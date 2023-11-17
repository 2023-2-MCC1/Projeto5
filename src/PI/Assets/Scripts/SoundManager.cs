using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    public AudioSource audioSource;
    
    /* 
        Essa função ficará responsável por gerenciar o áudio
        Através do slider que está no menu de configurações
    */
    public void SoundMenu(float value){
        audioSource.volume = value;
    }
}
