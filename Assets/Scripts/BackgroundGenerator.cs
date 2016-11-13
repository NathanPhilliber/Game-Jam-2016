using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject[] cloud;
    public GameObject volcano_1;
    public GameObject volcano_2;
    public GameObject mountain;
    public GameObject pillar;

    // Use this for initialization
    void Start()
    {
        placeClouds();
    }

    // Update is called once per frame
    void Update()
    {

    }

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
            Instantiate(volcano_1, new Vector3(Random.Range(-50f, 100f), 3 * 6 + 3f), Quaternion.identity);
        }
    }
}
