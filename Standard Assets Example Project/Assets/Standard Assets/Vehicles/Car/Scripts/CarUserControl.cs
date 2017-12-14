using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// this file is used for the controls on the car.
// It receives values from InputsOutputs.cs
// Last, it makes a call to the car to move

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

    public float switchIsOn;
    // public float frontSwitch;
    // public float leftSwitch;
    // public float rightSwitch;
    public float h;
    public float v;
    public float handbrake;
    public float mySteering;
    public CarController m_Car; // the car controller we want to use


        public void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        h = 0;
        }

        public void MoveCar(float h, float v, float handbrake)
        {
            m_Car.Move(h, v, v, handbrake);
        }

        public void FixedUpdate()
        {
            // pass the input to the car!

            // if(switchIsOn > 0){
            //     // don't change any values, because they were changed in InputsOutputs.
            // }
            // else{
            //     // no switches are on, so control the car as normal

            //     h = CrossPlatformInputManager.GetAxis("Horizontal");
            //     v = CrossPlatformInputManager.GetAxis("Vertical");

            //     handbrake = CrossPlatformInputManager.GetAxis("Jump");
            // }

         m_Car.Move(h, v, v, handbrake);
        }
    }
}
