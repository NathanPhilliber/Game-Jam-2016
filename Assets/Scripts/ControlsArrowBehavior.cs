using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlsArrowBehavior : MonoBehaviour {

	public GameObject player;
	public bool boss;
	public static int done;
	private bool imdone;
	public AudioClip ding;
	private AudioSource source;
	int counter = 0;
	private int delay = 0;
	// Use this for initialization
	void Start () {
		done = 0;
		imdone = false;
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!imdone && player.transform.position.x > transform.position.x) {
			done++;
			imdone = true;
			GetComponent<SpriteRenderer> ().enabled = false;
			source.PlayOneShot (ding);
		}
		counter++;
		if (counter > 20) {
			counter = 0;
		}
		transform.Translate (new Vector3(.05f*Time.deltaTime*(counter-10),0,0));

		if (boss) {
			if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene(1);
            }
            if (done >= 3)
            {
                delay++;
                print("BEGIN GAME");
                if (delay > 10)
                {
                    SceneManager.LoadScene(1);
                }
            }
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
			}

		}
	}
}
