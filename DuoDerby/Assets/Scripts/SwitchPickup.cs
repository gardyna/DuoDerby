using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class SwitchPickup : MonoBehaviour {
	public Animator anim;
	private bool working = true;
	public float high;
	public float low;

	IEnumerator OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (working) {
				working = false;
				float spawnDelay;
				//Renderer rend = GetComponent<Renderer>();
				//rend.enabled = false;
				anim.SetBool("Play", true);
				other.gameObject.GetComponentInParent<CarUserControl>().Switch();
				spawnDelay = Random.Range(low,high);
				yield return new WaitForSeconds(spawnDelay);
				anim.SetBool("Play", false);
				//rend.enabled = true;
				working = true;
			}
			
		}
	}
}
