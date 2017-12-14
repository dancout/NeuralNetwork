using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car {

	public class InputsOutputs : MonoBehaviour {

		public CarUserControl m_CarUserControl; // the car user controller we want to use

		// inputs
		public float frontSwitch; // this switch is toggled from the FrontCollider.cs
		public float rightSwitch; // this switch is toggled from the RightCollider.cs
		public float leftSwitch; // this switch is toggled from the LeftCollider.cs

		// outputs
		public float h;
		public float v;
		public float handbrake;


		// Use this for initialization
		void Start () {
			// initialize all colliders to zero, because they shouldn't be touching anything
			frontSwitch = 0;
			rightSwitch = 0;
			leftSwitch = 0;
		}
		
		// Update is called once per frame
		void Update () {

	        // call the car user controller to control the car
	        m_CarUserControl.h = h;
	        m_CarUserControl.v = v;
	        m_CarUserControl.handbrake = handbrake;

		}


	}

}
