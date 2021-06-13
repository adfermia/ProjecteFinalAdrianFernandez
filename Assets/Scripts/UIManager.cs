using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{

    public AudioSource clip;
   public GameObject optionsPanel;

   public void OptionsPanel() {
       // Parar el tiempo
       Time.timeScale = 0;
       // Activar el panel
       optionsPanel.SetActive(true);
   }
   public void Return(){
        // Parar el tiempo
       Time.timeScale = 1;
       //Desactivar el panel
       optionsPanel.SetActive(false);
   }
   public void AnotherOptions() {
       // Sonido
       //Grafico
       //etc
   }

   public void GoMainMenu() {
       Time.timeScale = 1;
       SceneManager.LoadScene("MainMenu");
   }
   public void QuitGame() {
       Application.Quit();
   }

   public void PlaySoundButton() {
       clip.Play();
   }
}
