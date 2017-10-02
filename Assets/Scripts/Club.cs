using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	Vector3 precendentePos;
	bool shoot;
	bool waitBall;
	public GameObject ball;
	float power;

	public GameObject hole;

	public int score;

	// Use this for initialization
	void Start () {
		score = -15;
		power = 0;
		waitBall = false;
		shoot = false;
		precendentePos = transform.position;
	}

	public void reset(){
		score += 5;
		if (score == 0)
			Debug.Log ("You lost.. but continue");
		Debug.Log ("Score: "+score);

		waitBall = false;

		if (ball.transform.position.y > hole.transform.position.y) {
			Vector3 temp = ball.transform.position;
			temp.y += 0.2f;
			transform.position = temp;
			Vector3 localScaleTemp = transform.localScale;
			localScaleTemp.y = -1;
			transform.localScale = localScaleTemp;
		} else {
			Vector3 temp = ball.transform.position;
			temp.y -= 0.2f;
			transform.position = temp;
			Vector3 localScaleTemp = transform.localScale;
			localScaleTemp.y = 1;
			transform.localScale = localScaleTemp;
		}
		precendentePos = transform.position;

	}

	void startShoot(){
		shoot = false;

		ball.GetComponent<Ball> ().shoot = true;
		ball.GetComponent<Ball> ().power = power;
		if (ball.transform.position.y > hole.transform.position.y)
			ball.GetComponent<Ball> ().directionTOP = false;
		else
			ball.GetComponent<Ball> ().directionTOP = true;

		waitBall = true;
		power = 0;
	}
		

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.Space) && waitBall == false) {
			shoot = true;
			if (power < 15f) {
				if (ball.transform.position.y > hole.transform.position.y)
					transform.Translate (new Vector3 (0, 3f, 0) * Time.deltaTime);
				else
					transform.Translate (new Vector3 (0, -3f, 0) * Time.deltaTime);
				power += 0.5f;
			}
		} else if (shoot == true) {
			if (ball.transform.position.y > hole.transform.position.y) {
				if (transform.position.y > precendentePos.y) {
					transform.Translate (new Vector3 (0, -15f, 0) * Time.deltaTime);
					
				}
				else {
					startShoot();
				}
			} 
			else{
				if (transform.position.y < precendentePos.y) {
					transform.Translate (new Vector3 (0, 15f, 0) * Time.deltaTime);
				}
				else {
					startShoot();
				}
			}

		}



	}
}
