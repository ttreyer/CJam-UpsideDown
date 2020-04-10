using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextSceneID;

    private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.gameObject.CompareTag("Finish"))
       {
           SceneManager.LoadScene (nextSceneID);
       }
    }
}
