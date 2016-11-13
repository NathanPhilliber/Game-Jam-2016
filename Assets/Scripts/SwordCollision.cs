using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

    public Camera2DFollow camera;
    private int counter;

    // Use this for initialization
    void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            counter++;
            if (counter > 3)
            {
                other.GetComponent<EnemyBehavior>().Damage(40f, true, transform.position);
                counter = 0;
            }
        }
    }
    void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            camera.Shake(new Vector3(8, 8, 0));
        }
    }
}
