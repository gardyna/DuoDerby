using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class SwitchPickup : MonoBehaviour {
	public GameObject Player;
	private bool working = true;

	IEnumerator OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			if (working) {
				Debug.Log("Enter!!!");
				working = false;
				Renderer rend = GetComponent<Renderer>();
				rend.enabled = false;
				other.gameObject.GetComponentInParent<CarUserControl>().Switch();
				yield return new WaitForSeconds(10);
				rend.enabled = true;
				working = true;
				Debug.Log("Done");
			}
			
		}
	}
}
