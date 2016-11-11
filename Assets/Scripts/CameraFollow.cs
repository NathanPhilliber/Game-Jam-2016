using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (target.transform.position.x-transform.position.x, 0, 0));
	}
}
