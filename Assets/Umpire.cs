﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Umpire : MonoBehaviour {

    public BananoCommunicator playercomm;
    AudioSource audioplayer;

    void Start()
    {
        PlayerPrefs.SetFloat("Bananos", 0);
        audioplayer = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<ObstacleMover>() != null)
        {
            // Debug.Log("detected");
            if (collision.gameObject.GetComponent<ObstacleMover>().banano)
            {
                playercomm.CmdMissBanano();
                Destroy(collision.gameObject);
                return;
            }

            Destroy(collision.gameObject);

            return;
        }

        else if (collision.gameObject.name == "MonkeyPlayer")
        {
            playercomm.GameOver();
            Destroy(collision.gameObject);
        }

        else return;

    }

    public void CollectBanano()
    {
        playercomm.CmdCollectBanano();

        float b = PlayerPrefs.GetFloat("Bananos");
        b += 1;

        Debug.Log(b);

        PlayerPrefs.SetFloat("Bananos", b);

        audioplayer.Play();

    }

    public void EndGame()
    {
        playercomm.GameOver();
    }

}
