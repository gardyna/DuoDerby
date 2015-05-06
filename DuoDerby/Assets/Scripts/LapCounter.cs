using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class LapCounter : MonoBehaviour {
	public List<Transform> pointList = new List<Transform>();
	public int numlaps;
	public Transform car;
	public Animator anim;
	public int range;

	private int numpoints;
	public Transform nextPoint;
	private int index;

	// Use this for initialization
	void Start () {
		numpoints = pointList.Count;
		nextPoint = pointList[0];
		car.GetComponent<CarUserControl>().enabled = true;
		car.GetComponent<WaypointProgressTracker>().enabled = false;
		car.GetComponent<CarAIControl>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		// check distance to next point
		float dist = Vector3.Distance(car.position, nextPoint.position);
		if (dist < range && index < numpoints) {
			nextPoint = pointList[index];
			index++;
		} else if (index == numpoints) {
			numlaps--;
			index = 0;
			nextPoint = pointList[0];
		}
		if (numlaps == 0) {
			StartCoroutine(endRace());
			endRace();

		}
	}

	IEnumerator endRace() {
		anim.SetBool("Showing", true);
		numlaps = -1;
		car.GetComponent<CarUserControl>().enabled = false;
		car.GetComponent<WaypointProgressTracker>().enabled = true;
		car.GetComponent<CarAIControl>().enabled = true;
		yield return new WaitForSeconds(10);
		Application.LoadLevel("MainMenu");
	}
}
