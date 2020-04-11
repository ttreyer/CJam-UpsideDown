using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.gameObject.CompareTag("Finish"))
       {
           SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
           Destroy(GameObject.FindGameObjectWithTag("MusicController"));
       }
    }
}
