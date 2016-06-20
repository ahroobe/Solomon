using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class dragEvent : MonoBehaviour {
	public Vector2 nowPos, prePos, movePos;
	private bool goingUp;
	private bool goingDown;
	public float gravity;
	public float jump;
	public float widthspeed;
	public float maxheight;
	private float nowheight;
	public float maxwidth;
	private float nowx;
	private bool leftmove;
	private bool rightmove;
	private bool go;
	private bool back;
	private bool touching;
	//public AudioClip jump_sound;
	public AudioSource jumpsource;
	public AudioSource movesource;
	// Use this for initialization
	Vector3 jumpDirection;
	Vector3 leftDirection;
	Vector3 rightDirection;

	void Start () {
		touching = false;
		goingUp = false;
		goingDown = false;
		leftmove = false;
		rightmove = false;
		go = false;
		back = false;
		nowheight = 0;
		nowx = 0;
		jumpDirection = new Vector3 (0, jump, 0);
		leftDirection = new Vector3 (-widthspeed, 0, 0);
		rightDirection = new Vector3 (widthspeed, 0, 0);


	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {

			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				prePos = touch.position - touch.deltaPosition;
			} else if (touch.phase == TouchPhase.Moved && !goingDown && !goingUp && !rightmove && !leftmove &&!touching) {
				
				nowPos = touch.position - touch.deltaPosition;
				movePos = (prePos - nowPos);
				if (movePos.x > 100) {
					movesource.Play ();
					touching = true;
					//left collision action
					leftmove = true;
					nowx = nowx + widthspeed;
					transform.Translate (leftDirection);
					go = true;

				} else if (movePos.y < -50) {
					touching = true;
					//jump action
					jumpsource.Play();
					GetComponent<Animation> ().Play ("Jump");
					transform.Translate (jumpDirection);
					nowheight = nowheight + jump;
					goingUp = true;
				} else if (movePos.x < -100) {
					movesource.Play ();
					touching = true;
					//right collision action
					rightmove = true;
					nowx = nowx + widthspeed;
					transform.Translate (rightDirection);
					go = true;
				}
			} else if (touch.phase == TouchPhase.Ended) {
				touching = false;
			}

		}
		//jumping
		if (goingUp) {
			if (nowheight < maxheight) {
				transform.Translate (jumpDirection);
				nowheight = nowheight + jump;
			} else {
				goingUp = false;
				goingDown = true;

			}
		} else if (goingDown) {
			if (nowheight == 0) {
				goingDown = false;
				GetComponent<Animation> ().Play ("Walk");
			} else {
				transform.Translate (0, gravity, 0);
				nowheight = nowheight + gravity;
			}
		}
		//go left and back
		if (leftmove) {
			if (nowx == 0 && back) {
				leftmove = false;
				back = false;
			} else if (go) {
				transform.Translate (leftDirection);
				nowx = nowx + widthspeed;
				if (nowx == maxwidth) {
					go = false;
					back = true;
				}
			} else if (back) {
				transform.Translate (rightDirection);
				nowx = nowx - widthspeed;
			}
		}
		//go right and back
		if (rightmove) {
			if (nowx == 0 && back) {
				rightmove = false;
				back = false;
			} else if (go) {
				transform.Translate (rightDirection);
				nowx = nowx + widthspeed;
				if (nowx == maxwidth) {
					go = false;
					back = true;
				}
			} else if (back) {
				transform.Translate (leftDirection);
				nowx = nowx - widthspeed;
			}
		}



	}
}
