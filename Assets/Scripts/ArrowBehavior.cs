using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {

	public float arrowPower;
	public bool isRight;

	// Use this for initialization
	void Start () {
		if (isRight) {
			GetComponent<Rigidbody> ().AddForce (Vector3.right * arrowPower + Vector3.up * arrowPower / 5, ForceMode.Impulse);
		} else {
			GetComponent<Rigidbody> ().AddForce (Vector3.left * arrowPower + Vector3.up * arrowPower / 5, ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Ground")) {
			Destroy (gameObject);
		} else if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyBehavior> ().Damage (60f, false, Vector3.zero);
		}
	}
}
