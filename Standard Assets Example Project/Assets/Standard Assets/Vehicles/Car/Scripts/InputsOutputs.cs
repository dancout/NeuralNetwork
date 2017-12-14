using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car {

	public class InputsOutputs : MonoBehaviour {

		public CarUserControl m_CarUserControl; // the car user controller we want to use

		// inputs
		public float frontSwitch;
		public float rightSwitch;
		public float leftSwitch;

		// outputs
		public float h;
		public float v;
		public float handbrake;


		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {

	        // update the car user controller after looking through inputs
	        m_CarUserControl.h = h;
	        m_CarUserControl.v = v;
	        m_CarUserControl.handbrake = handbrake;

		}


	}

}
