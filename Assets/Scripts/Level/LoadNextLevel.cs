using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.gameObject.CompareTag("Finish"))
       {
           TransitionController transitionController = GameObject.FindGameObjectWithTag("TransitionController").GetComponent<TransitionController>();
           transitionController.NextLevel();
       }
    }
}
