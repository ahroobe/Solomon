using UnityEngine;
using System.Collections;

public class GirlActions : MonoBehaviour {
    public GameObject sportygirl;

    Actions actions;
    PlayerController controller;
	// Use this for initialization
	void Start () {
        Initialize();
	}
	
    void Initialize()
    {
        actions = sportygirl.GetComponent<Actions>();
        controller = sportygirl.GetComponent<PlayerController>();
        actions.Run();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
