﻿using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Renderer> ().material.color = Color.red;
    }

}
