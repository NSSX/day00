using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public float speed;
	public GameObject limit;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		
	}

	public void deleteBloc(){
		parent.GetComponent<CubeSpawner> ().canSpawn = true;
		GameObject.Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (0, speed, 0) * Time.deltaTime);
		if (transform.position.y <= limit.transform.position.y - 1f) {
			//pop
			deleteBloc();
		}
	}
}
