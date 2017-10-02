using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject bloc;
	public int place;
	KeyCode keycode;

	float counter;
	float interval;

	public GameObject limit;

	public bool canSpawn;

	GameObject currentGO;

	// Use this for initialization
	void Start () {
		canSpawn = true;
		if (place == 1)
			keycode = KeyCode.A;
		else if (place == 2)
			keycode = KeyCode.S;
		else if (place == 3)
			keycode = KeyCode.D;
		else
			keycode = KeyCode.A;


		counter = 0;
		interval = getRandomInterval ();
	}

	float getRandomInterval(){
		return Random.Range (0.5f,1.5f);
	}

	// Update is called once per frame
	void Update () {

		if(canSpawn == true)
			counter += Time.deltaTime;
		if (counter >= interval) {
			counter = 0;
			currentGO = GameObject.Instantiate (bloc, transform.position, Quaternion.identity);
			currentGO.GetComponent<Cube> ().speed = Random.Range (-5,-9); //(-0.05f,-0.12f);
			currentGO.GetComponent<Cube> ().limit = limit;
			currentGO.GetComponent<Cube> ().parent = gameObject;
			canSpawn = false;
		}
	
		if (Input.GetKeyDown (keycode) && canSpawn == false) {
			float precision = currentGO.transform.position.y - limit.transform.position.y;
			if (precision < 0)
				precision = -precision;
			Debug.Log ("Precision: "+precision);
			currentGO.GetComponent<Cube> ().deleteBloc ();
		}

	}
}
