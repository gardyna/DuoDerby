using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof (CarController))]
	public class CarUserControl : MonoBehaviour
	{


		private CarController m_Car; // the car controller we want to use
		public int driver;
		public int engine;
		private Launcher m_launch;
		public float offRoad;
		
		
		private void Awake()
		{
			// get the car controller
			m_Car = GetComponent<CarController>();
			m_launch = GetComponentInChildren<Launcher>();
			offRoad = 1.0f;
		}
		
		
		private void FixedUpdate()
		{
			// pass the input to the car!
			float h = CrossPlatformInputManager.GetAxis("Horizontal_p" + driver.ToString());
			float v = CrossPlatformInputManager.GetAxis("Vertical_p" + engine.ToString());
			#if !MOBILE_INPUT
			//float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, v * offRoad, v, 0f);
			m_launch.rotate(CrossPlatformInputManager.GetAxis("Horizontal_p" + engine.ToString()));
			if (Input.GetAxis("Fire" + engine.ToString()) != 0) {
				StartCoroutine(m_launch.Fire());
			}

			#else
			m_Car.Move(h, v, v, 0f);
			#endif
		}
		
		public void Switch() {
			if (driver == 1) {
				driver = 2;
				engine = 1;
			} else {
				driver = 1;
				engine = 2;
			}
		}
	}
}
