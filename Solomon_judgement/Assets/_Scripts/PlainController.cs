using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlainController : MonoBehaviour {

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public AudioSource diesource;
	public AudioSource wrongsource;

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
			if (other.gameObject.tag.Length == 7) {
			if (KittenController.life > 0) {
				KittenController.life = KittenController.life - 1;
				if (KittenController.life == 1) {
					//2nd die
					heart2.SetActive (false);
				} else if (KittenController.life == 2) {
					heart3.SetActive (false);
				} else if (KittenController.life == 0) {
					heart1.SetActive (false);
					
					Time.timeScale = 0;
                    SceneManager.LoadScene("Result");
                    Time.timeScale = 1;

                }
			} 

				wrongsource.Play ();

			}
            foreach (GameObject se in see)
            {
			
                Destroy(se);

            }
      
        
    }

}