using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class SwitchPickup : MonoBehaviour {
	public Animator anim;
	private bool working = true;

	IEnumerator OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (working) {
				working = false;
				Renderer rend = GetComponent<Renderer>();
				rend.enabled = false;
				anim.SetBool("Play", true);
				other.gameObject.GetComponentInParent<CarUserControl>().Switch();
				yield return new WaitForSeconds(10);
				anim.SetBool("Play", false);
				rend.enabled = true;
				working = true;
			}
			
		}
	}
}
