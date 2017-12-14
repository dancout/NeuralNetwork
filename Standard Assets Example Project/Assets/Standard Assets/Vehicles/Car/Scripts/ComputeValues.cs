using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{

	public class ComputeValues : MonoBehaviour {

		 public InputsOutputs m_InOut;
		 public NeuralNetwork m_Network;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			// Update the input layer for the neural network
			List<float> inputLayer = new List<float>();
			inputLayer.Add(m_InOut.frontSwitch);
			inputLayer.Add(m_InOut.rightSwitch);
			inputLayer.Add(m_InOut.leftSwitch);

			m_Network.inputLayer = inputLayer;

			
			// grab the outputs from the neural network output layer
	        float h = m_Network.outputLayer[0];
	        float v = m_Network.outputLayer[1];
	        float handbrake = m_Network.outputLayer[2];

	        // set these output values to the InputsOutputs class (to be used for the carusercontroller)
	        m_InOut.h = h;
        	m_InOut.v = v;
        	m_InOut.handbrake = handbrake;
	       
		}
	}

}