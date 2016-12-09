using UnityEngine;
using System.Collections;

public class RedPlayer_Move : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode rightKey;
	public KeyCode leftKey;

	public KeyCode rightCTRL;

	public float speed = 16;

	public GameObject lightWallPrefab_Red;
	public GameObject lightWallPrefab_Yellow;

	public AudioClip High_One;
	public AudioClip High_Two;
	public AudioClip High_Three;
	public AudioClip High_Four;
	public AudioClip MH_One;
	public AudioClip MH_Two;
	public AudioClip MH_Three;
	public AudioClip MH_Four;

	// 0 - red, 1 - yellow
	int lastWallColor;
	int newWallColor;

	int lastKeyPressed; 

	bool changeColor = true;

	Collider2D wall;

	//Last wall's end
	Vector2 lastWallEnd;

	// Use this for initialization
	void Start () {

		//Initial Velocity for player objects
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

		SpawnWall();
	
	}

	void OnTriggerEnter2D(Collider2D co) {

		if (co != wall){

			if (co.gameObject.tag == "BlueWall" || co.gameObject.tag == "VioletWall"){

			if (changeColor = true){
			
				if (lastKeyPressed == 0){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(High_Four);

					Debug.Log ("Up", co);
				}
				else if (lastKeyPressed == 1){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(High_One);

					Debug.Log ("Down", co);
				}
				else if (lastKeyPressed == 2){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(High_Three);

					Debug.Log ("Right", co);
				}
				else if (lastKeyPressed == 3){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(High_Two);

					Debug.Log ("Left", co);
				}

			}

			else if (changeColor = false){
				
				if (lastKeyPressed == 0){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(MH_Four);

					Debug.Log ("Up", co);
				}
				else if (lastKeyPressed == 1){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(MH_One);

					Debug.Log ("Down", co);
				}
				else if (lastKeyPressed == 2){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(MH_Three);

					Debug.Log ("Right", co);
				}
				else if (lastKeyPressed == 3){

					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot(MH_Two);

					Debug.Log ("Left", co);
				}
			
			}

		}

		}
	}

	void SpawnWall(){

		//Save Last Wall's position
		lastWallEnd = transform.position;

		//Spawn new lightwall	
		string wallColor = "";
		GameObject g = new GameObject();
		switch(newWallColor){
			case 0:
				g = (GameObject)Instantiate(lightWallPrefab_Red, transform.position, Quaternion.identity);
				break;
			case 1:
				g = (GameObject)Instantiate(lightWallPrefab_Yellow, transform.position, Quaternion.identity);
				break;
		}
		wall = g.GetComponent<Collider2D>();


	}

	void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b) {

		//Center Position calc
		co.transform.position = a + (b - a) *0.5f;

		//Scale horiz or vertically
		float dist = Vector2.Distance(a, b);
		if (a.x != b.x)
			co.transform.localScale = new Vector2(dist + 1, 1);
		else
			co.transform.localScale = new Vector2(1, dist + 1);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(rightCTRL)){

			if (changeColor == true){
			newWallColor = 0;
			destroyLastWalls();
		}
		else if (changeColor == false){
			newWallColor = 1;
			destroyLastWalls();
		}

			changeColor = !(changeColor);

			SpawnWall();

		}

		if (Input.GetKeyDown(upKey)){

			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

			SpawnWall();

			lastKeyPressed = 0;
			//Up

		}
		else if (Input.GetKeyDown(downKey)){

			GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;

			SpawnWall();

			lastKeyPressed = 1;
			//Down

		}
		else if (Input.GetKeyDown(rightKey)){

			GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

			SpawnWall();

			lastKeyPressed = 2;
			//Right

		}
		else if (Input.GetKeyDown(leftKey)){

			GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;

			SpawnWall();

			lastKeyPressed = 3;
			//Left

		}

		fitColliderBetween(wall, lastWallEnd, transform.position);
	
	}

	void destroyLastWalls(){
		if(!(lastWallColor == newWallColor)){
			string tag = "";
			switch(lastWallColor){
				case 0:
					tag = "RedWall";
					break;
				case 1:
					tag = "YellowWall";
					break;
			}
			GameObject[] lastWalls = GameObject.FindGameObjectsWithTag(tag);
			foreach(GameObject go in lastWalls){
				Destroy(go);
			}
			lastWallColor = newWallColor;
			SpawnWall();
		}
	}


	void OnBecameInvisible() {
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;
        Vector2 pos = gameObject.transform.position;
        if (vel.x != 0) {
        	pos.x *= -1;
        	pos.y -= 2;
        } else if (vel.y != 0){
        	pos.y *= -1;
        	pos.x -= 2;
        }
        gameObject.transform.position = pos;
        SpawnWall();
        print(gameObject.transform.position.x + ", " + gameObject.transform.position.y);
    }
}