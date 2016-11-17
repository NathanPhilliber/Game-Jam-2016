using UnityEngine;
using System.Collections;

public class WorldControlManager : MonoBehaviour {

	public const int HEAVEN = 0;
	public const int EARTH = 1;
	public const int HELL = 2;

	public static bool heavenEnabled;
	public static bool earthEnabled;
	public static bool hellEnabled;

	public AudioClip changeSound;
	public AudioClip playerDeathSound;
	private AudioSource source;

	public static int enabledWorld;

	public SpriteRenderer arrowSprite;
	public bool arrowMarkerEnabled;

	public Transform cam0;
	public Transform cam1;
	public Transform cam2;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		heavenEnabled = true;
		hellEnabled = true;
		earthEnabled = true;

		enabledWorld = EARTH;
	}

	public void PlayPlayerDeathSound(){
		source.PlayOneShot (playerDeathSound);
	}

	void UpdateArrow(){
		if (arrowMarkerEnabled) {
			switch (enabledWorld) {
			case 0:
				arrowSprite.transform.position = new Vector3 (cam0.position.x-3.5f, cam0.position.y, arrowSprite.transform.position.z);
				break;
			case 1:
				arrowSprite.transform.position = new Vector3 (cam1.transform.position.x-3.5f, cam1.position.y, arrowSprite.transform.position.z);
				break;
			case 2:
				arrowSprite.transform.position = new Vector3 (cam2.transform.position.x-3.5f, cam2.position.y, arrowSprite.transform.position.z);
				break;
				
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateArrow ();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

		if (enabledWorld == HEAVEN) {
			if (!earthEnabled && !hellEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !hellEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && earthEnabled)) {
				enabledWorld = EARTH;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && hellEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !earthEnabled)) {
				enabledWorld = HELL;
				source.PlayOneShot (changeSound);
			}

		} else if (enabledWorld == EARTH){
			if (!heavenEnabled && !hellEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && heavenEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !hellEnabled)) {
				enabledWorld = HEAVEN;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !heavenEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && hellEnabled)) {
				enabledWorld = HELL;
				source.PlayOneShot (changeSound);
			}

		} else if (enabledWorld == HELL){
			if (!earthEnabled && !heavenEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && earthEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !heavenEnabled)) {
				enabledWorld = EARTH;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !earthEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && heavenEnabled)) {
				enabledWorld = HEAVEN;
				source.PlayOneShot (changeSound);
			}

		}
	}
}
