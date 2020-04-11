using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private float fadeOutDuration = 0.7f;
    [SerializeField] private float fadeInDuration = 0.7f;

        
    private Image _image;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
        
        StartLevel();
    }

    public void StartLevel()
    {
        _image.DOFade(0, fadeOutDuration);
    }

    public void NextLevel()
    {
        _image.DOFade(1, fadeInDuration).OnComplete(() =>
        {
            SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
            Destroy(GameObject.FindGameObjectWithTag("MusicController"));
        });
    }
}
