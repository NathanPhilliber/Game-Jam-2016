using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverBehavior : MonoBehaviour {

	private AudioSource source;
	public AudioClip song;
	private GameObject score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (song);
		score = GameObject.FindGameObjectWithTag ("Score");
		scoreText.text = "Score: "+ score.GetComponent<ScoreManager>().score;
		Destroy (score.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && Time.frameCount > 100) {
			SceneManager.LoadScene (0);
		}
	}
}
