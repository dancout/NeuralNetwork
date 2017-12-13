﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car {

	public class RightCollider : MonoBehaviour {

		 public CarController m_Car; // the car controller we want to use
		 public CarUserControl m_CarUserControl;

		// Use this for initialization
		void Start () {}

		public void Awake(){}

        void OnTriggerEnter(Collider other)
        {
        	m_CarUserControl.rightSwitch = -2;
        }

		 void OnTriggerStay(Collider other)
	    {
	    	m_CarUserControl.rightSwitch = -2;
	    }

	    void OnTriggerExit(Collider other)
	    {
	    	m_CarUserControl.rightSwitch = 0;
	    }
		
		// Update is called once per frame
		void Update () {

			// Applies an upwards force to all rigidbodies that enter the trigger.		
		}
	}

}
