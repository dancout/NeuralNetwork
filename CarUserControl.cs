using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

    public float asd;
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


        public void FixedUpdate()
        {
            // pass the input to the car!
            
        
        h = CrossPlatformInputManager.GetAxis("Horizontal");
        v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
        handbrake = CrossPlatformInputManager.GetAxis("Jump");
        if(asd > 10)
            m_Car.Move(h, v, v, handbrake);
        else {
            h = 0;
            v = 0;
            handbrake = 0;
            m_Car.Move(h, v, v, handbrake); }

        
    
#else

#endif
        }
    }
}
