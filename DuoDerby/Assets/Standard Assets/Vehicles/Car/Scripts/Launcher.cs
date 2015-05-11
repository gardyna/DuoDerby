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
			Vector3 x = transform.parent.localEulerAngles;
			transform.rotation = Quaternion.Euler(new Vector3(x.x, x.y + (v * maxAngle), x.z));
			//transform.RotateAround(transform.parent.position, new Vector3(0, 1 ,0), (v * maxAngle));
		}
	}
}