using UnityEngine;
using System.Collections;

public class SwordBehavior : MonoBehaviour {

	private Quaternion startRotation;
	private Vector3 startPosition;
	public float swordSpeed;

	private bool isSwinging = false;
	private float rot = 0;

	// Use this for initialization
	void Start () {
		startRotation = transform.rotation;
		startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			isSwinging = true;
		}

		if (isSwinging) {
			transform.rotation *= Quaternion.Euler(new Vector3(0,0,-1*swordSpeed));
			rot += -1 * swordSpeed;

			if (Mathf.Abs (rot) < 100) {
				transform.localPosition += Vector3.right * swordSpeed*.01f;
			} else {
				transform.localPosition += Vector3.left * swordSpeed*.01f;
			}




			if (Mathf.Abs (rot) > 200) {
				isSwinging = false;
				rot = 0;
				transform.rotation = startRotation;
				transform.localPosition = startPosition;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyBehavior> ().Damage (20f, true, transform.position);
		}
	}
}
