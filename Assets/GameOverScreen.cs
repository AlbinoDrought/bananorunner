﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    [SerializeField]
    Text Bananos;

	// Use this for initialization
	void Start () {
		
	}

    public void SetBananos()
    {
        Bananos.text = PlayerPrefs.GetFloat("Bananos").ToString() + " Bananos";
    }

}
