using UnityEngine;
using System.Collections;

public class CameraBorder : MonoBehaviour {

    public Texture2D textureImage;
    public Texture2D black;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        int barWidth = Screen.height / 74;

        GUI.DrawTexture(new Rect(0, Screen.height / 3 - barWidth,  Screen.width, barWidth), black);

        GUI.DrawTexture(new Rect(0, Screen.height / 3 * 2 + 1,     Screen.width, barWidth), black);

        int world = WorldControlManager.enabledWorld;

        Rect borderSize = new Rect(0, world * Screen.height / 3, Screen.width, Screen.height / 3);
        GUI.DrawTexture(borderSize, textureImage);
    }
}
