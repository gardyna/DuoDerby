using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car {
	public class Launcher : MonoBehaviour {
		public GameObject projectile;
		private bool fireable = true;
		[SerializeField] private int maxAngle;
		[SerializeField] private RectTransform gameCanvas;
		[SerializeField] private RectTransform crosshair;

		public IEnumerator Fire() {
			if (fireable) {
				fireable = false;
				Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y -1, this.transform.position.z), transform.rotation);
				yield return new WaitForSeconds(1);
				fireable = true;
			}
		}

		// Update is called once per frame
		public void rotate(float v) {
			Vector3 x = transform.parent.localEulerAngles;
			transform.rotation = Quaternion.Euler(new Vector3(x.x, x.y + (v * maxAngle), x.z));
			crosshair.transform.position = new Vector3(((gameCanvas.rect.width/2)*v)+(gameCanvas.rect.width/2)+90, crosshair.transform.position.y, crosshair.transform.position.z);
			//crosshair.rect.x = (gameUI.rect.width / 2) * v;
		}
	}
}