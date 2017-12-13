using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car {

	// [RequireComponent(typeof (CarController))]
	public class FrontCollider : MonoBehaviour {

		 public CarController m_Car; // the car controller we want to use
		 public CarUserControl m_CarUserControl;

		// Use this for initialization
		void Start () {
			// m_Car = GetComponent<CarController>();
			
			
		}

		  public void Awake()
        {
            // get the car controller
            // m_Car = GetComponent<CarController>();
  
        }

        void OnTriggerEnter(Collider other)
        {
        	m_CarUserControl.nodeInput = -2;
	    	m_CarUserControl.MoveCar(-1,-1,0);
        }

		 void OnTriggerStay(Collider other)
	    {
	    	// m_Car = GetComponent<CarController>();
	    	m_CarUserControl.nodeInput = -2;
	    	m_CarUserControl.MoveCar(-1,-1,0);
	     	// m_Car.Move(0, -10, 0, 0);
	    }

	    void OnTriggerExit(Collider other)
	    {
	    	m_CarUserControl.nodeInput = 0;
	    }
		
		// Update is called once per frame
		void Update () {

			// Applies an upwards force to all rigidbodies that enter the trigger.


			
		}
	}

}