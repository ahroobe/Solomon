using UnityEngine;
using System.Collections;

public class StreetAction : MonoBehaviour {

	public GameObject[] RoadPieces = new GameObject[2];
	const float RoadLength = 30f;
	const float RoadSpeed = 7f;
	// Update is called once per frame
	void Update () {
	
		foreach (GameObject road in RoadPieces) {
			Vector3 newRoadPos = road.transform.position;
			newRoadPos.z -= RoadSpeed * Time.deltaTime;
			if (newRoadPos.z < -RoadLength / 2) {
				newRoadPos.z += RoadLength;
			}
			road.transform.position = newRoadPos;
	
		}
	}
}
