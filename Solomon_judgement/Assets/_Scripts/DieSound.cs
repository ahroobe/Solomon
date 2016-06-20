using UnityEngine;
using System.Collections;

public class DieSound : MonoBehaviour {
    public AudioSource diesource;
    public InstantGuiElement scoreText;
    // Use this for initialization
    void Start () {
        diesource.Play();
        scoreText.text = "Your score is "+ KittenController.score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
