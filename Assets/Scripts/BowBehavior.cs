using UnityEngine;
using System.Collections;

public class BowBehavior : MonoBehaviour {

	public GameObject arrow;
	public bool isRight;
	public PlayerController player;
	public int maxChargeTime;
	private int charge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.dimension == WorldControlManager.enabledWorld) {
			if (isRight && Input.GetKey (KeyCode.RightArrow)) {
				charge++;
				if (charge >= maxChargeTime) {
					Instantiate (arrow, transform.position, Quaternion.identity);
					charge = 0;
				}
			}
			if (!isRight && Input.GetKey (KeyCode.LeftArrow) ) {
				
				charge++;
				if (charge >= maxChargeTime) {
					Instantiate (arrow, transform.position, Quaternion.identity);
					charge = 0;
				}
			}
		}
	}
}
