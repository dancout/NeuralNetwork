using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{

	public class ComputeValues : MonoBehaviour {

		 public InputsOutputs m_InOut;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			// check if any switches are on

			m_InOut.v = 1;
			m_InOut.h = 0;
			m_InOut.handbrake = 0;

	        if(m_InOut.rightSwitch > 0) {
	        	m_InOut.h = -0.5F;
	        	m_InOut.v = 1;
	        	m_InOut.handbrake = 0;
	        }

	        if(m_InOut.frontSwitch > 0){
	           m_InOut. h = 0;
	          	m_InOut.v = -1;
	            m_InOut.handbrake = 0;
	        }
			
			if(m_InOut.leftSwitch > 0) {
	        	m_InOut.h = 0.5F;
	        	m_InOut.v = 1;
	        	m_InOut.handbrake = 0;
	        }
		}
	}

}