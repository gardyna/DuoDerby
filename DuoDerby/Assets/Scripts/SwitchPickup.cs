using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class SwitchPickup : MonoBehaviour {
	public GameObject Player;

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			Debug.Log("Enter!!!");
			other.gameObject.GetComponentInParent<CarUserControl>().Switch();
			this.GetComponent<Renderer>().enabled = false;
			StartCoroutine(Wait());
			this.GetComponent<Renderer>().enabled = false;
		}
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(2);
	}
}
