using UnityEngine;
using System.Collections;

public class WorldControlManager : MonoBehaviour {

	public const int HEAVEN = 0;
	public const int EARTH = 1;
	public const int HELL = 2;

	public AudioClip changeSound;
	private AudioSource source;

	public static int enabledWorld = EARTH;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (enabledWorld == EARTH || enabledWorld == HELL) {
				enabledWorld--;
				source.PlayOneShot (changeSound);
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (enabledWorld == HEAVEN || enabledWorld == EARTH) {
				enabledWorld++;
				source.PlayOneShot (changeSound);
			}
		}
	}
}
