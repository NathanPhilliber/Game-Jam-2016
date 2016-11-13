using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleBehavior : MonoBehaviour {

	public Image title1;
	public Image title2;
	public Image title3;
	public Image cont;

	public AudioClip backgroundMusic;
	private AudioSource source;

	private int counter = 0;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (backgroundMusic);
	}

	// Update is called once per frame
	void Update () {
		counter++;

		if (counter == 100) {
			title3.CrossFadeAlpha (0, 5f, false);
		}

		if (counter == 350) {
			title2.CrossFadeAlpha (0, 5f, false);
		}

		if (counter == 700) {
			title3.CrossFadeAlpha (1, 5f, false);
		}

		if (counter == 1000) {
			title2.CrossFadeAlpha (1, 0f, false);
			counter = 0;
		}

		cont.transform.Translate (new Vector3(0,Time.deltaTime*10f*Mathf.Sign((counter-500)%5),0));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKeyDown) {
			//START
			print("START GAME");
			source.Pause ();
			SceneManager.LoadScene (1);
			//START
		}
	}
}
