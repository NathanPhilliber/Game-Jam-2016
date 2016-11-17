using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {

	public float arrowPower;
	public bool isRight; //Is this arrow facing right?

	// Use this for initialization
	void Start () {

		//Add the force right away, based on which side to fire at
		if (isRight) {
			GetComponent<Rigidbody> ().AddForce (Vector3.right * arrowPower + Vector3.up * arrowPower / 10, ForceMode.Impulse);
		} else {
			GetComponent<Rigidbody> ().AddForce (Vector3.left * arrowPower + Vector3.up * arrowPower / 10, ForceMode.Impulse);
		}
	}

	//Check for collisions
	void OnTriggerEnter(Collider other){

		//If ground, destroy arrow
		if (other.CompareTag ("Ground")) {
			Destroy (gameObject);
		} 

		//If hit enemy, damage enemy and destroy arrow after a small amount of time
		else if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyBehavior> ().Damage (60f, false, Vector3.zero);
            Destroy(gameObject, .01f);
		}
	}
}
