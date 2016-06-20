using UnityEngine;
using System.Collections;

public class SpawnHumans : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float[] spawnTime = { 1.5f, 1.0f, 2.0f };

    public GameObject[] Humans;
    //public GameObject[] Coins;
    public GameObject fakeBox;
    int couples = 0;
    int solos = 0;
    int obstacles = 0;
    string[] coupletag = { "couple1", "couple2", "couple3", "couple4", "couple5" };
    string[] solotag = { "solo1", "solo2", "solo3", "solo4"};
    string[] obstag = { "bin1", "bin2", "bin3", "bin4" };

    // Use this for initialization
    void Start() {
        int TimeIndex = Random.Range(0, spawnTime.Length);

        InvokeRepeating("SpawnHuman", 1.3f, spawnTime[TimeIndex]);
        couples = 0;
        solos = 0;
        obstacles = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnHuman()
    {

        int spawnIndex = Random.Range(0, SpawnPoints.Length);//set index number of array randomly.
        int HumanIndex = Random.Range(0, Humans.Length);
        GameObject gamechar = (GameObject)Instantiate(Humans[HumanIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        GameObject fakeBox2 = (GameObject) Instantiate(fakeBox, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        if ((HumanIndex % 2 == 0))
        {
            string tag1 = coupletag[couples];
            gamechar.tag = tag1;
            fakeBox2.tag = tag1;
            if (couples == 4)
            {
                couples = 0;
            }else
            {
                couples = couples + 1;
            }
       

        } else if (HumanIndex % 2 == 1 && HumanIndex < 6)
        {
            string tag2 = solotag[solos];
            gamechar.tag = tag2;
            fakeBox2.tag = tag2;
            if (solos == 3)
            {
                solos = 0;
            }else
            {
                solos = solos + 1;
            }
        } else
        {
            string tag3 = obstag[obstacles];
            gamechar.tag = tag3;
            fakeBox2.tag = tag3;
            if (obstacles == 3)
            {
                obstacles = 0;
            }
            else
            {
                obstacles = obstacles + 1;
            }
        }
        /*
        Rigidbody rigd = fakeBox.AddComponent<Rigidbody> ();
        rigd.isKinematic = true;
        rigd.useGravity = true;
        //rigd.velocity = transform.TransformDirection(Vector3.back * 10);
        CapsuleCollider capsule = rigd.gameObject.AddComponent<CapsuleCollider>();
        
        //capsule.direction = 2;
        //humanrigd = capsule.attachedRigidbody;
        capsule.radius = 1.0f;
        capsule.height = 2.0f;
        capsule.isTrigger = true;
        */
    }
}
