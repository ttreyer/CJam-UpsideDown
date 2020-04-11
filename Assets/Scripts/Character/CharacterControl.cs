﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    private void OnReset(InputValue value)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
