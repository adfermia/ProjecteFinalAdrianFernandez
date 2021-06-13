using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
   public Text text;
   public string levelName;
   private bool indoor = false;


   private void OnTriggerEnter2D(Collider2D collision) {
       if (collision.gameObject.CompareTag("Player")){
           text.gameObject.SetActive(true);
           indoor = true;
       }
   } 
   private void OnTriggerExit2D(Collider2D collision) {
        text.gameObject.SetActive(false);
        indoor = false;
   }
    private void Update() {
        if(indoor && Input.GetKey("e")){
            SceneManager.LoadScene(levelName);
        }
    }
}
