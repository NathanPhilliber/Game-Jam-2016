using UnityEngine;
using System.Collections;

public class FlameBehavior : MonoBehaviour {


	public float power;


	// Use this for initialization
	void Start () {
		
	}

	public void Fire(Rigidbody playerRb, bool isRight){
		
		Vector3 yV = Vector3.zero;
		if (Random.Range (0, 2) == 0) {
			yV = Vector3.up;
		} else {
			yV = Vector3.down;
		}


		Vector3 move = new Vector3 (power, Random.Range(-1.1f,1.1f),0);
		if (!isRight) {
			move = new Vector3 (-power, Random.Range(-1.1f,1.1f),0);
		}

		GetComponent<Rigidbody> ().velocity = playerRb.velocity + move;

		Destroy (gameObject, Random.Range(.4f,.8f));
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyBehavior> ().Damage (10, false, Vector3.zero);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
