using UnityEngine;
using System.Collections;

public class BearDance : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown (KeyCode.Space))
        {
            anim.SetTrigger("dance");
        }
	}
}
