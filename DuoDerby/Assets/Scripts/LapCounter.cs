using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour {
	public List<Transform> pointList = new List<Transform>();
	public int numlaps;
	public Transform car;
	public Animator anim;
	public int range;
	public Text UItext;

	private int numpoints;
	private int lapNum = 1;
	private int totalLaps;
	private Transform nextPoint;
	private int index;

	// Use this for initialization
	void Start () {
		numpoints = pointList.Count;
		nextPoint = pointList[0];
		car.GetComponent<CarUserControl>().enabled = true;
		car.GetComponent<WaypointProgressTracker>().enabled = false;
		car.GetComponent<CarAIControl>().enabled = false;
		UItext.text = "Lap: 1/" + numlaps.ToString();
		totalLaps = numlaps;
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
			lapNum++;
			UItext.text = "Lap: " + lapNum.ToString() + "/" + totalLaps.ToString();
			index = 0;
			nextPoint = pointList[0];
		}
		if (numlaps == 0) {
			UItext.text = "Lap: " + totalLaps.ToString() + "/" + totalLaps.ToString();
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
