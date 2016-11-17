using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject[] cloud;
    public GameObject volcano;
    public GameObject mountain;
    public GameObject[] pillars;


    // Use this for initialization
    void Start()
    {
        placeClouds();
    }

	//Place all of the background image objects
    void placeClouds()
    {
        for (int i = 0; i < cloud.GetLength(0); i++)
        {
            for (int j = 0; j < 25; j++)
            {
                Instantiate(cloud[i], new Vector3(Random.Range(-50f, 100f), (i - 1) * 6 + 2.2f + Random.Range(-0.92f, 0.82f), 0.2f), Quaternion.identity);
            }
        }

        for (int i = 0; i < 25; i++)
        {
            int scale = Random.Range(0, 3);

            float y_value = -5.643f;

            if (scale == 1)
            {
                volcano.transform.localScale = new Vector3(.5f, .5f, .5f);
                y_value = -5.8f;
            }
            if (scale == 2)
            {
                volcano.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                y_value = -5.4f;
            }

            Instantiate(volcano, new Vector3(Random.Range(-50f, 100f), y_value, 0.2f), Quaternion.identity);       
        }

        for (int i = 0; i < pillars.GetLength(0); i++)
        {
            for (int j = 0; j < 23; j++)
            {
                float y_value = i == 2 ? 6.6f - .1f : 6.6f;
                Instantiate(pillars[i], new Vector3(Random.Range(-50f, 100f), y_value, 0.2f), Quaternion.identity);
            }
        }

        for (int i = 0; i < 40; i++)
        {
            Instantiate(mountain, new Vector3(Random.Range(-50f, 100f), 0.45f, 0.2f), Quaternion.identity);
        }
    }
}
