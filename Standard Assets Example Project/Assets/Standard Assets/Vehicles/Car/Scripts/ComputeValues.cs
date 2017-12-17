using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{

	// Define our Node Class Type
	public class Node  {
		public float activationSum;
		public float bias;
		public float activationThreshold;
		public float output;

		// constructor
		public Node(float actSum, float b, float actThresh) {
			activationSum = actSum;
			bias = b;
			activationThreshold = actThresh;
			output = 0;
		}
	}	

	public class ComputeValues : MonoBehaviour {

		 public InputsOutputs m_InOut;
		 public NeuralNetwork m_Network;
		 public List<Node> inputLayer2 = new List<Node>();
		 public int numPrevLayerNodes = 3;
		 public List<Node> outputLayer2 = new List<Node>();

		// Use this for initialization
		void Start () {

			
			for (int i = 0; i < numPrevLayerNodes; i++){
				inputLayer2.Add(new Node(0F, Random.value, Random.value));
			}


			List<Node> outputLayer2 = new List<Node>();
			for (int i = 0; i < 4; i++){
				outputLayer2.Add(new Node(0F, Random.value, 1.5F));
			}


			m_Network.outputLayer2 = outputLayer2;

			int num = 3 * 4; // 3 input nodes * 2 output nodes
			for(int i = 0; i < num; i++){
			// weights.Add(Random.value);
			m_Network.weights.Add(Random.value);
			}

		// // hardcoding to make car move forward
		// m_Network.weights[0] = 0F;
		// m_Network.weights[1] = 0F;
		// m_Network.weights[2] = 0F;
		// m_Network.weights[4] = 0F;
		// m_Network.weights[5] = 0F;
		// m_Network.weights[6] = 0F;
		// m_Network.weights[8] = 0F;

			
		}
		
		// Update is called once per frame
		void Update () {
			// Update the input layer for the neural network
			List<float> inputLayer = new List<float>();
			inputLayer.Add(m_InOut.frontSwitch);
			inputLayer.Add(m_InOut.rightSwitch);
			inputLayer.Add(m_InOut.leftSwitch);

			m_Network.inputLayer = inputLayer;


			for(int i = 0; i < numPrevLayerNodes; i++){
				inputLayer2[i].activationSum = inputLayer[i];
			}

			m_Network.inputLayer2 = inputLayer2;
			


			
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