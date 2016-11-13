using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraBorder : MonoBehaviour {

    public Texture2D textureImage;
    public Texture2D black;
    private bool fade;

    // Use this for initialization
    void Start () {
        fade = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public Texture2D fadeTexture;
    float fadeSpeed = -0.2f;
    int drawDepth = -1000;

    private float alpha = 1.0f;
    private int fadeDir = -1;

    public void fadeOut()
    {
        fade = true;
    }

    void OnGUI()
    {
        if (alpha > 0 && !fade)
        {
            alpha -= fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(0, 0, 0, alpha);

            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
         }


        int barWidth = Screen.height / 74;

        GUI.DrawTexture(new Rect(0, Screen.height / 3 - barWidth,  Screen.width, barWidth), black);

        GUI.DrawTexture(new Rect(0, Screen.height / 3 * 2,     Screen.width, barWidth), black);

        int world = WorldControlManager.enabledWorld;

        Rect borderSize = new Rect(0, world * Screen.height / 3, Screen.width, Screen.height / 3);
        GUI.DrawTexture(borderSize, textureImage);

        print(fade);

        if (alpha < 1.0f && fade)
        {
            print(alpha);
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(0, 0, 0, alpha);

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
        else if (alpha >= 1.0f && fade)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            SceneManager.LoadScene(2);
        }
        
    }
}
