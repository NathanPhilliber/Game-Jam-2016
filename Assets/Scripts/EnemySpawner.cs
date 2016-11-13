using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject heavenPlayer;
	public GameObject earthPlayer;
	public GameObject hellPlayer;

	public GameObject enemy1;

	public float minSpawnRadius;
	public int initialSpawnChance; //Lower the more spawns
	public int maxSpawns;
	public static int spawns;
    private int old_alive;
    private int minimumSpawn = 50;
    private bool firstFrame = true;

    private int spawnChance;

	// Use this for initialization
	void Start () {
        spawns = 0;
        spawnChance = initialSpawnChance;

        InvokeRepeating("increaseSpawnChance", 10.0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        print(spawnChance);

        int alive =  3 - PlayerController.alivePlayers.Count + 1;

        if(alive != old_alive && !firstFrame)
        {   
            spawnChance /= 2;
            minimumSpawn -= 15;
        }

        firstFrame = false;

        old_alive = 3 - PlayerController.alivePlayers.Count + 1;

        if (Input.GetKeyDown (KeyCode.P)) {
			print ("Current Spawns: " + spawns);
		}

		if (Random.Range (0, spawnChance) == 0 && spawns < maxSpawns) {
			Vector3 spawnPos = Vector3.zero;
			GameObject thisPlayer = PlayerController.GetRandomAlivePlayer ();
			spawnPos = thisPlayer.transform.position;


			int dir = Random.Range (0, 2);
			if (dir == 0) {
				dir = -1;
			}

			spawnPos = new Vector3 (spawnPos.x + (float)dir * minSpawnRadius, spawnPos.y, spawnPos.z);

			GameObject spawn = (GameObject)Instantiate (enemy1, spawnPos, Quaternion.identity);
			spawn.GetComponent<EnemyBehavior> ().SetTarget (thisPlayer);
		}
	}
    
    void increaseSpawnChance()
    {
        if (spawnChance > 50)
        {
            spawnChance--;
        }
    }
}
