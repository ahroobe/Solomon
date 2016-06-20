using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KittenController : MonoBehaviour {

	public AudioSource hitsource;
	public AudioSource wrongsource;
	public AudioSource diesource;

	public static int life = 3;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public InstantGuiElement scoreText;
	public static int score;
	int count;
	// Use this for initialization
	void Start () {
		life = 3;
		score = 0;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag.Length == 7) {
			GameObject[] objs;

			objs = GameObject.FindGameObjectsWithTag (other.gameObject.tag);
			foreach (GameObject obj in objs) {
				Destroy (obj);
				hitsource.Play ();
			}
			score = score + 10;
			scoreText.text = score.ToString();

		} else {
			GameObject[] objs;
			objs = GameObject.FindGameObjectsWithTag (other.gameObject.tag);
			foreach (GameObject obj in objs) {
				Destroy (obj);
				wrongsource.Play ();
			}
			if (life > 0) {
				life = life - 1;
				if (life == 1) {
					//2nd die
					heart2.SetActive (false);
				} else if (life == 2) {
					heart3.SetActive (false);
				} else if (life == 0) {
					heart1.SetActive (false);
					
					Time.timeScale = 0;
                    SceneManager.LoadScene("Result");
                    Time.timeScale = 1;
                }
			}
			}





	}
}
