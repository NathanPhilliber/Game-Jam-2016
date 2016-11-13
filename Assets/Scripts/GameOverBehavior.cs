using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverBehavior : MonoBehaviour {

	private AudioSource source;
	public AudioClip song;
	private GameObject score;
	public Text scoreText;
    private int counter;

	// Use this for initialization
	void Start () {
        counter = 0;
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (song);
		score = GameObject.FindGameObjectWithTag ("Score");
		scoreText.text = "Score: "+ score.GetComponent<ScoreManager>().score;
		Destroy (score.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        counter++;
		if (Input.anyKeyDown && counter > 100) {
			SceneManager.LoadScene (0);
		}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
