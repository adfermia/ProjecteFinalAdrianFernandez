using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public GameObject transition;
    private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.CompareTag("Player")) {
           transition.SetActive(true);
           Invoke("ChangeScene", 1);
           
       }
   }

   void ChangeScene() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
