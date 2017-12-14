using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car {

	public class LeftCollider : MonoBehaviour {

		 public InputsOutputs m_InOut;

		// Use this for initialization
		void Start () {}

		public void Awake(){}

        void OnTriggerEnter(Collider other)
        {
        	m_InOut.leftSwitch = 1;
        }

		 void OnTriggerStay(Collider other)
	    {
	    	m_InOut.leftSwitch = 1;
	    }

	    void OnTriggerExit(Collider other)
	    {
	    	m_InOut.leftSwitch = 0;
	    }
		
		// Update is called once per frame
		void Update () {

			// Applies an upwards force to all rigidbodies that enter the trigger.
		}
	}

}
