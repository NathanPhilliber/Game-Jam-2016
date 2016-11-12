using UnityEngine;
using System.Collections;

public class FlameThrowerBehavior : MonoBehaviour {

	public GameObject flame;
	public Rigidbody playerRb;
	public PlayerController player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.dimension == WorldControlManager.enabledWorld) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				GameObject spawned = (GameObject)Instantiate (flame, transform.position, Quaternion.identity);
				spawned.GetComponent<FlameBehavior> ().Fire (playerRb, true);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				GameObject spawned = (GameObject)Instantiate (flame, transform.position, Quaternion.identity);
				spawned.GetComponent<FlameBehavior> ().Fire (playerRb, false);
			}
		}
	}
}
