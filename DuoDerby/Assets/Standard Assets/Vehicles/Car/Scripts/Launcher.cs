using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car {
	public class Launcher : MonoBehaviour {
		public GameObject projectile;

		private bool fireable = true;
		[SerializeField]
		private int maxAngle;

		public IEnumerator Fire() {
			if (fireable) {
				fireable = false;
				Instantiate(projectile, this.transform.position, transform.rotation);
				yield return new WaitForSeconds(1);
				fireable = true;
			}
		}

		// Update is called once per frame
		public void rotate(float v) {
			transform.rotation = Quaternion.Euler(new Vector3(0, v * maxAngle, 0));
		}
	}
}