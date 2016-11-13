using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text text;
	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void AddScore(int delta){
		score += delta;
		text.text = score + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
