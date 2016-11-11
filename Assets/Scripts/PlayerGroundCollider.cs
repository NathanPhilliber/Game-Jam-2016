using UnityEngine;
using System.Collections;

public class PlayerGroundCollider : MonoBehaviour {


	public bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Ground")) {
			grounded = true;
		}
	}
		
}
