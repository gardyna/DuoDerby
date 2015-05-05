using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LapCounter : MonoBehaviour {
	public Collider finish_line;
	public List<Transform> pointList = new List<Transform>();
	public int numlaps;
	public Transform car;
	public Animator anim;

	private int numpoints;
	public Transform nextPoint;
	private int index;

	// Use this for initialization
	void Start () {
		numpoints = pointList.Count;
		nextPoint = pointList[0];
	}
	
	// Update is called once per frame
	void Update () {
		// check distance to next point
		float dist = Vector3.Distance(car.position, nextPoint.position);
		if (dist < 5 && index < numpoints) {
			Debug.Log("changing points");
			nextPoint = pointList[index];
			index++;
		} else if (index == numpoints) {
			numlaps--;
			index = 0;
			nextPoint = pointList[0];
		}
		if (numlaps == 0) {
			//Debug.Log("race finished");
			StartCoroutine(endRace());
			endRace();

		}
	}

	IEnumerator endRace() {
		Debug.Log("entered function");
		anim.SetBool("Showing", true);
		numlaps = -1;
		yield return new WaitForSeconds(10);
		Application.LoadLevel("MainMenu");
	}
}
