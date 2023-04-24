using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject levelMusic;
    public GameObject winMusic;
    public GameObject loseMusic;


    void Start()
    {
        levelMusic.SetActive(true);
        winMusic.SetActive(false);
        loseMusic.SetActive(false);
    }

    void Update()
    {
        
        if ((BotFixCount.winActive == true)||(BotFixCount.continueActive == true))
            Win();

        if (RubyController.dead == true)
            Lose();
    }

    void Win()
    {
        winMusic.SetActive(true);
        levelMusic.SetActive(false);
    }

    void Lose()
    {
        loseMusic.SetActive(true);
        levelMusic.SetActive(false);
    }
}
