using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	float counterTimer;

	float localScaleStart;
	int soufle;

	float counterSoufle;
	float intervalSoufle;

	int essouflement;
	bool resetEssouflement;

	// Use this for initialization
	void Start () {
		resetEssouflement = true;
		essouflement = 0;
		counterSoufle = 0;
		intervalSoufle = 0.5f;
		soufle = 100;
		localScaleStart = transform.localScale.x;
	}


	// Update is called once per frame
	void Update () {

		counterTimer += Time.deltaTime;

		counterSoufle += Time.deltaTime;
		if (counterSoufle >= intervalSoufle) {
			counterSoufle = 0;
			soufle += 40;
			if (soufle > 100)
				soufle = 100;
			if (resetEssouflement == true) {
				essouflement = 2;
			} else {
				resetEssouflement = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && soufle >= 10) {
			transform.localScale += new Vector3 (0.2f,0.2f,0);
			soufle -= essouflement;
			essouflement += 2;
			resetEssouflement = false;
			if (transform.localScale.x >= localScaleStart * 2.1f) {
				Debug.Log ("GG YOU WIN");
				Debug.Log ("Balloon life time: "+Mathf.RoundToInt(counterTimer)+"s");
				GameObject.Destroy (gameObject);
			}
		}

		if (transform.localScale.x - 0.01f >= 0) {
			transform.localScale -= new Vector3 (0.01f, 0.01f, 0);
		} else {
			Debug.Log ("YOU LOST");
			Debug.Log ("Balloon life time: "+Mathf.RoundToInt(counterTimer)+"s");
			GameObject.Destroy (gameObject);
		}


		if (counterTimer >= 15f) {
			Debug.Log ("TOO LATE...");
			Debug.Log ("Balloon life time: "+Mathf.RoundToInt(counterTimer)+"s");
			GameObject.Destroy (gameObject);
		}
	}
}
