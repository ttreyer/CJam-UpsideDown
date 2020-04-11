using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMusic : MonoBehaviour
{
    private MusicController _mc;
    // Start is called before the first frame update
    void Start()
    {
        _mc = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>();
    }

    public void SetMusicInWater()
    {
        _mc.ToggleMusicInWater();
    }

    public void SetMusicInAir()
    {
        _mc.ToggleMusicInAir();
    }
}
