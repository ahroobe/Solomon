using UnityEngine;
using System.Collections;

public class SpawnHumans : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float[] spawnTime = { 1.5f, 1.0f, 2.0f };

    public GameObject[] Humans;
    //public GameObject[] Coins;


	// Use this for initialization
	void Start () {
        int TimeIndex = Random.Range(0, spawnTime.Length);

        InvokeRepeating("SpawnHuman", 1.5f, spawnTime[TimeIndex]);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void SpawnHuman()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);//set index number of array randomly.
        int HumanIndex = Random.Range(0, Humans.Length);
        Instantiate(Humans[HumanIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }
}
