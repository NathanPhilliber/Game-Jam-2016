using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleBehavior : MonoBehaviour {

	//3 Purgatory Images
	public Image title1;
	public Image title2;
	public Image title3;

	//Press to start text
	public Text cont;

	public AudioClip backgroundMusic;
	private AudioSource source;

	//Counters for when to change image and move text
	private int counter = 99;
	private int counter2 = 0;

	//Starting position of moving text
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (backgroundMusic);
		startPos = cont.transform.position;
	}

	// Update is called once per frame
	void Update () {
		counter++;

		//Cross fade between the 3 images
		if (counter == 100) {
			title3.CrossFadeAlpha (0, 5f, false);
		}
		if (counter == 400) {
			title2.CrossFadeAlpha (0, 5f, false);
		}
		if (counter == 800) {
			title3.CrossFadeAlpha (1, 5f, false);
		}

		//End of crossfade cycle
		if (counter == 1100) {
			title2.CrossFadeAlpha (1, 0f, false);
			counter = 0;
			counter2++;

			//Every 5 text move cycles, reset to starting position
			if (counter2 > 5) {
				cont.transform.position = startPos;
				counter2 = 0;
			}
		}

		//Move the text up and down
		cont.transform.Translate (new Vector3(0,Time.deltaTime*10f*Mathf.Sign((counter-640)%5),0));

		//Press escape to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

		//Start game if any other key is pressed
        if (Input.anyKeyDown) {
			source.Pause ();
			SceneManager.LoadScene (3);
		}
	}
}
