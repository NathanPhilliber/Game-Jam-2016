using UnityEngine;
using System.Collections;

public class PlayerAntiStuck : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Ground")) {
			//playerRb.velocity += Vector3.up * .9f;
			player.transform.Translate(Vector3.up*.1f);

		}
		if (other.CompareTag ("Enemy")) {
			player.GetComponent<PlayerController> ().Damage (5f);
		}
	}
}
