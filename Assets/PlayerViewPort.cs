﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewPort : MonoBehaviour {

    [SerializeField]
    GameObject containerObj;
    [SerializeField]
    GameObject containerPrefab;

    [SerializeField]
    ServerReferee referee;

    public void ClearViewport()
    {
        if (containerObj.transform.childCount == 0)
            return;

        foreach(Transform child in containerObj.transform.GetComponentsInChildren<Transform>())
        {
            if (child != containerObj.transform)
                Destroy(child.gameObject);
        }
    }

    public void ShowOnlinePlayers()
    {
        ClearViewport();

        PlayerTracker.PlayerDB db = new PlayerTracker.PlayerDB();

        foreach (PlayerTracker.PlayerContainer c in referee.pinterface.container)
        {
            string tmpwallet = c.GetWallet();

            string[] playerdat = db.GetPlayerData(tmpwallet);

            GameObject newContainer = Instantiate(containerPrefab, containerObj.transform);

            newContainer.GetComponent<PlayerInfoContainer>().SetupContainer(tmpwallet, playerdat[0], playerdat[1], playerdat[2]);

        }


    }

	public void ShowAllPlayers()
    {
        ClearViewport();

        PlayerTracker.PlayerDB db = new PlayerTracker.PlayerDB();

        if (PlayerPrefs.HasKey("AllWallets"))
        {
            string[] allwallets = PlayerPrefs.GetString("AllWallets").Split('|');

            foreach (string s in allwallets)
            {

                string[] playerdat = db.GetPlayerData(s);

                GameObject newContainer = Instantiate(containerPrefab, containerObj.transform);

                newContainer.GetComponent<PlayerInfoContainer>().SetupContainer(s, playerdat[0], playerdat[1], playerdat[2]);

            }

        }

    }

}