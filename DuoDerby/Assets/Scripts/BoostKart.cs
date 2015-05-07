using UnityEngine;
using System.Collections;

public class BoostKart : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	private bool launched;
	private int count;
	void Start() {
		rb = GetComponent<Rigidbody>();
		launched = false;
		count = 0;
	}

	void Update() {
		if (launched && (count > 0)) {
			count = count - 1;
			rb.AddForce (transform.forward * thrust);
		} 
		else if (launched && (count <= 0)) {
			launched = false;
		}
	}

	void OnTriggerEnter(Collider other){
//		Debug.Log ("Entered object");
		if (other.gameObject.CompareTag ("Boost")) {
			launched = true;
			count = 10;
//			Debug.Log("Triggered");
		}

	}
}
