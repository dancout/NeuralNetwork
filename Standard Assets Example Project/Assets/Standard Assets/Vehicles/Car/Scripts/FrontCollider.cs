﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car {

	// [RequireComponent(typeof (CarController))]
	public class FrontCollider : MonoBehaviour {

		 public InputsOutputs m_InOut;

		// Use this for initialization
		void Start () {}

		public void Awake(){}

        void OnTriggerEnter(Collider other)
        {
        	// m_CarUserControl.frontSwitch = 1;
        	m_InOut.frontSwitch = 1;
	    	// m_CarUserControl.MoveCar(-1,-1,0);
        }

		 void OnTriggerStay(Collider other)
	    {
	    	// m_CarUserControl.frontSwitch = 1;
	    	m_InOut.frontSwitch = 1;
	    	// m_CarUserControl.MoveCar(-1,-1,0);
	    }

	    void OnTriggerExit(Collider other)
	    {
	    	// m_CarUserControl.frontSwitch = 0;
	    	m_InOut.frontSwitch = 0;
	    }
		
		// Update is called once per frame
		void Update () {

			// Applies an upwards force to all rigidbodies that enter the trigger.
		}
	}

}