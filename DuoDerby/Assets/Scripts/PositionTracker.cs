using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PositionTracker : MonoBehaviour {
	public List<GameObject> karts;
	public List<GameObject> points;
	public Text PosText;
	private int index = 0;
	public Transform player;
	public int changeRange;


	private GameObject nextPoint;
	// Use this for initialization
	void Start () {
		nextPoint = points[index];
	}
	
	// Update is called once per frame
	void Update () {
		karts.Sort(delegate(GameObject c1, GameObject c2) {
			return Vector3.Distance(nextPoint.transform.position, c1.transform.position).CompareTo
						((Vector3.Distance(nextPoint.transform.position, c2.transform.position)));
		});

		if (Vector3.Distance(karts[0].transform.position, nextPoint.transform.position) < changeRange) {
			nextPoint = points[index];
			index++;
			if (index == points.Count) index = 0;
		}

		for (int i = 0; i < karts.Count; i++) {
			if (karts[i].transform == player.transform) {
				//TODO: change UI
				PosText.text = "position: " + (i + 1).ToString();
			}
		}
	}
}
