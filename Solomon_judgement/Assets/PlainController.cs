using UnityEngine;
using System.Collections;

public class PlainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
      GameObject[] see;

            see = GameObject.FindGameObjectsWithTag(other.gameObject.tag);
            foreach (GameObject se in see)
            {
                Destroy(se);
            }
      
        
    }

}