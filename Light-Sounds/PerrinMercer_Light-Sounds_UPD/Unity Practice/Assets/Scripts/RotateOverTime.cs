using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour {

    public float rotateSpeed = 5.0f;
    //Appears as checkbox, checked == true
    //public bool truthy;
    //Gives inputable x, y, and z 
    //public Vector3 vec;
    //Bring up color selector
    //public Color Col;
    //Gives options for curves for animation movements
    //public AnimationCurve ac;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);

	}
}
