using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private int force;
	[SerializeField]
	private int uppForce;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(transform.forward * force);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, uppForce, 0));
		}
		Destroy(this);
	}
}
