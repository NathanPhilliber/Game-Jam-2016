﻿using UnityEngine;
using System.Collections;

public class FlameThrowerBehavior : MonoBehaviour {

	public GameObject flame;
	public Rigidbody playerRb;
	public PlayerController player;

	public int maxFuel;
	private int fuel;

	private int soundCooldown;

	public AudioClip throwerSound;
	private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		fuel = maxFuel;
		soundCooldown = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.dimension == WorldControlManager.enabledWorld) {

			if (fuel < maxFuel) {
				fuel++;
			}
			if (soundCooldown <= 50) {
				soundCooldown++;
			}
			if (Input.GetKey (KeyCode.RightArrow) && fuel > 0) {
				fuel -=2;
				GameObject spawned = (GameObject)Instantiate (flame, transform.position, Quaternion.identity);
				spawned.GetComponent<FlameBehavior> ().Fire (playerRb, true, fuel, maxFuel);
				if (Input.GetKeyDown (KeyCode.RightArrow) && soundCooldown > 50) {
					source.PlayOneShot (throwerSound);
					soundCooldown = 0;
				}
			}
			if (Input.GetKey (KeyCode.LeftArrow) && fuel > 0) {
				fuel -=2;
				GameObject spawned = (GameObject)Instantiate (flame, transform.position, Quaternion.identity);
				spawned.GetComponent<FlameBehavior> ().Fire (playerRb, false, fuel, maxFuel);
				if (Input.GetKeyDown (KeyCode.LeftArrow) && soundCooldown > 50) {
					source.PlayOneShot (throwerSound);
					soundCooldown = 0;
				}
			}
		}
	}
}