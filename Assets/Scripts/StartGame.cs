using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void OnJump(InputValue value)
    {
        TransitionController transitionController = GameObject.FindGameObjectWithTag("TransitionController").GetComponent<TransitionController>();
        
        transitionController.NextLevel();
    }
}
