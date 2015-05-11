using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private int force;
	[SerializeField]
	private int uppForce;
	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody>().AddForce(transform.forward * force);
		WaitAndDestroy();
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.tag);
		if (other.tag == "Enemy") {
			Debug.Log("HIT!!");
			other.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, uppForce, 0));
		}
	}

	IEnumerator WaitAndDestroy() {
		yield return new WaitForSeconds(3);
		Destroy(this);
	}
}
