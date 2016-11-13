using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text text;
	public int score = 0;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		
		text.text = "Score: 0";
		InvokeRepeating("AddOneScore", 1f, 1f);
	}

	public void Reset(){
		score = 0;
	}

	public void AddScore(int delta){
		score += delta;
		text.text = "Score: "+score;
	}
	public void AddOneScore()
	{
		AddScore (PlayerController.alivePlayers.Count);
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
