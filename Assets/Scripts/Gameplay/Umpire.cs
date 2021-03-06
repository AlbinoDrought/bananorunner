﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Umpire : MonoBehaviour {

    public BananoCommunicator playercomm;
    AudioSource audioplayer;

    [SerializeField]
    ScoreUIManager scoremanager;

    void Start()
    {
        //PlayerPrefs.SetFloat("Bananos", 0);
        //PlayerPrefs.Save();
        audioplayer = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<ObstacleMover>() != null)
        {
            // Debug.Log("detected");
            if (collision.gameObject.GetComponent<ObstacleMover>().banano)
            {
                playercomm.MissBanano();
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
        playercomm.CollectBanano();

        scoremanager.AddPoint();

        audioplayer.Play();

    }

    public void EndGame()
    {
        playercomm.GameOver();
    }

    public void CheckPoint()
    {
        scoremanager.TallyPoints();
    }

    public void RcheckPoint()
    {
        playercomm.Rcheckpoint();
    }

}
