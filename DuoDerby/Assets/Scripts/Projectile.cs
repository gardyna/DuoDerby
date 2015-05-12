using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private int force;
	[SerializeField]
	private int uppForce;
	[SerializeField]
	private GameObject explosion;
	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody>().AddForce(transform.forward * force);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.tag);
		if (other.tag == "Enemy") {
			Debug.Log("HIT!!");
			other.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, uppForce, 0));
		} if (other.tag != "Player") {
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			GetComponent<Renderer>().enabled = false;
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			StartCoroutine(WaitAndDestroy());
		}
	}

	IEnumerator WaitAndDestroy() {
		yield return new WaitForSeconds(1);
		Destroy(this.gameObject);
	}
}
