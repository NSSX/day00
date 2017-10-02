using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool shoot;
	public float power;
	public bool directionTOP;

	public GameObject topLimit;
	public GameObject botLimit;

	float limiter;

	public GameObject club;

	public GameObject hole;

	// Use this for initialization
	void Start () {
		limiter = 0.02f;
		directionTOP = true;
		shoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (shoot == true) {

			if (directionTOP == true) {
				transform.Translate (new Vector3(0,power,0) * Time.deltaTime);
			} else {
				transform.Translate (new Vector3(0,-power,0) * Time.deltaTime);
			}

			if (transform.position.y >= topLimit.transform.position.y) {
				directionTOP = false;
			}
				
			if (transform.position.y <= botLimit.transform.position.y) {
				directionTOP = true;
			}



		
			power -= limiter ;
			limiter += 0.01f;
			if (power <= 0) {
				power = 0;
				limiter = 0.02f;
				shoot = false;
				club.GetComponent<Club> ().reset ();
			}
		}

		if ((transform.position.y - hole.transform.position.y) * (transform.position.y - hole.transform.position.y) <= 0.04f && power <= 5f) {
			Debug.Log ("END");
			Debug.Log ("Score: "+ club.GetComponent<Club> ().score);
			GameObject.Destroy (gameObject);
			GameObject.Destroy (club);
		}
	}
}
