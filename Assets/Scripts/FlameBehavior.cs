using UnityEngine;
using System.Collections;

public class FlameBehavior : MonoBehaviour {

	public float power;


	// Use this for initialization
	void Start () {
		
	}

	public void Fire(Rigidbody playerRb, bool isRight, int fuel, int maxFuel){
		
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

		GetComponent<Rigidbody> ().velocity = playerRb.velocity + move*((float)fuel/(float)maxFuel);

		Destroy (gameObject, Random.Range(.6f*((float)fuel/(float)maxFuel),1.0f*((float)fuel/(float)maxFuel)));
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyBehavior> ().Damage (2.5f, false, Vector3.zero);
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
