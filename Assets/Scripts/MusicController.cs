using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicAir;
    [SerializeField] private AudioSource musicWater;
    [SerializeField] private bool forceNewMusic = false;
    [SerializeField] private float transitionDuration = 0.25f;

    private bool _isInWater;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musics = GameObject.FindGameObjectsWithTag("MusicController");
        if (musics.Length > 1)
        {
            if (forceNewMusic)
            {
                foreach (var m in musics)
                {
                    if (m == gameObject)
                        continue;
                    Destroy(m);
                }
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(gameObject);

        if (musicAir)
        {
            musicAir.Play();
        }

        if (musicWater)
        {
            musicWater.Play();
            musicWater.volume = 0.0f;
        }
    }

    public void ToggleMusicInWater()
    {
        musicWater.DOFade(0.75f, transitionDuration);
        musicAir.DOFade(0.0f, transitionDuration);
    }

    public void ToggleMusicInAir()
    {
        musicAir.DOFade(1.0f, transitionDuration);
        musicWater.DOFade(0.0f, transitionDuration);
    }
}