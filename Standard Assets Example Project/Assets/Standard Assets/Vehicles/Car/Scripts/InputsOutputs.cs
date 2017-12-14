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


			// check if any switches are on
			if((frontSwitch > 0) || (rightSwitch > 0) || (leftSwitch > 0)) {
				m_CarUserControl.switchIsOn = 1;
			}
			else {
				m_CarUserControl.switchIsOn = 0;
				v = 1;
				h = 0;
				handbrake = 0;
			}

	        if(rightSwitch > 0) {
	        	h = -0.5F;
	        	v = 1;
	        	handbrake = 0;
	        }

	        if(frontSwitch > 0){
	            h = 0;
	          	v = -1;
	            handbrake = 0;
	        }
			
			if(leftSwitch > 0) {
	        	h = 0.5F;
	        	v = 1;
	        	handbrake = 0;
	        }

	        // update the car user controller after looking through inputs
	        m_CarUserControl.h = h;
	        m_CarUserControl.v = v;
	        m_CarUserControl.handbrake = handbrake;

		}


	}

}
