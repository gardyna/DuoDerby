using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car {
	public class Launcher : MonoBehaviour {
		public GameObject projectile;

		private bool firing = true;

		public IEnumerator Fire() {
			firing = false;
			Instantiate(projectile, this.transform.position, transform.rotation);
			yield return new WaitForSeconds(1);
			firing = true;
			Debug.Log("Done");
		}

		// Update is called once per frame
		void Update() {
			//if ((Input.GetAxis("Fire1") != 0) && firing == true) {
				//StartCoroutine(Fire());
			//}
		}
	}
}