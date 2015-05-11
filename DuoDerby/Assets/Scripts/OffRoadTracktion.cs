using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class OffRoadTracktion : MonoBehaviour {
	[SerializeField]
	private float traction;
	private float defaultSpeed;

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player") {
			Debug.Log("Slow");
			defaultSpeed = collision.collider.GetComponentInParent<CarController>().MaxSpeed;
			collision.collider.GetComponentInParent<CarController>().MaxSpeed *= (1.0f - traction);
		}
		
	}

	void OnCollisionExit(Collision collisionInfo) {
		if (collisionInfo.collider.tag == "Player") {
			Debug.Log("Exit");
			collisionInfo.collider.GetComponentInParent<CarController>().MaxSpeed = defaultSpeed;
		}
	}
}
