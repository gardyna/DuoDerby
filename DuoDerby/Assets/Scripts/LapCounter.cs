using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LapCounter : MonoBehaviour {
	public Collider finish_line;
	public List<Transform> pointList = new List<Transform>();
	public int numlaps;
	public Transform car;

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
			nextPoint = pointList[index++];
		} else if (index == numpoints) {
			Debug.Log(index);
			numlaps--;
			index = 0;
			nextPoint = pointList[0];
		} else if (numlaps <= 0) {
			Debug.Log("race finished");
		}
	}
}
