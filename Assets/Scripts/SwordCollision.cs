using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

    public Camera2DFollow camera;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBehavior>().Damage(60f, true, transform.position);
            camera.Shake(new Vector3(8, 8, 0));
        }
    }
}
