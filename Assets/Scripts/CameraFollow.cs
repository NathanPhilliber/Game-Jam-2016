using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;

	private float startY;

	// Use this for initialization
	void Start () {
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.Translate (new Vector3 ((target.transform.position.x-transform.position.x)*Time.deltaTime, 0, 0));

		if (target.transform.position.y - transform.position.y > .5) {
			transform.Translate (new Vector3 (0, .5f*Time.deltaTime, 0));
		}

		if (target.transform.position.y - startY < 0 && transform.position.y > startY) {
			transform.Translate (new Vector3 (0, -2f*Time.deltaTime, 0));
		}
	}
}
