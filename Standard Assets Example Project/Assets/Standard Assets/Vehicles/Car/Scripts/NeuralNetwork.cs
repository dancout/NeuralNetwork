using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class NeuralNetwork : MonoBehaviour {

	public List<float> inputLayer = new List<float>(); // switch inputs
	public List<float> outputLayer = new List<float>(); // output values used for controlling the car
	public List<float> weights = new List<float>(); // for now, this represents the weights between the input and output layer (assuming only a 2 layer network)
	public List<Node> inputLayer2 = new List<Node>();
	public List<Node> outputLayer2 = new List<Node>();
	public float RSweight;// = Random.value;
	public float LSweight;// = Random.value;
	public float V1weight;
	public float V2weight;
	public float FS = 0;
	public float RS = 0;
	public float LS = 0;
// Define our Node Class Type
	// public class Node  {
	// 	public float activationSum;
	// 	public float bias;
	// 	public float activationThreshold;
	// 	public float output;

	// 	// constructor
	// 	public Node(float actSum, float b, float actThresh) {
	// 		activationSum = actSum;
	// 		bias = b;
	// 		activationThreshold = actThresh;
	// 		output = 0;
	// 	}
	// }	

	void runNode(Node node) {
		float finalSum = node.activationSum + node.bias;
		if(finalSum > node.activationThreshold) {
			node.output = 1;
		}
		else{
			node.output = 0;
		}

		node.activationSum = 0;
	}

	// Use this for initialization
	void Start () {
		// ONLY ADDED THIS TO INITIALIZE. THERE WAS AN ERROR BECAUSE THIS LIST WAS EMPTY AT THE START OF THE FUNCTION
		outputLayer.Add(0F);
		outputLayer.Add(0F);
		outputLayer.Add(0F);

		RSweight = Random.value;
		LSweight = Random.value;
		V1weight = Random.value;
		V2weight = Random.value;




	}
	
	// Update is called once per frame
	void Update () {
		// input layer should already be set from ComputeValues.cs
		// the below values are set as defaults. IE, if no switches are on, then just drive straight forward and slant a little to the right.
		float h;
		float v;
		float handbrake;


		// where the magic happens

		for (int i = 0; i < 3; i++){
			runNode(inputLayer2[i]);
		}

		FS = inputLayer2[0].activationSum;
		RS = inputLayer2[1].activationSum;
		LS = inputLayer2[2].activationSum;

		// multiply weights with input layer
		int numPrevLayerNodes = 3;
		int numNextLayerNodes = 4;

		// hardcoding here to make it just drive forward
		// outputLayer2[2].bias = 1F;

		for (int x = 0; x < numPrevLayerNodes; x++){
			float prevOutput = inputLayer2[x].output;
			for(int y = 0; y < numNextLayerNodes; y++){

				float value = weights[(x*numNextLayerNodes) + y];
				float num = prevOutput * value;

				float placeHolder = outputLayer2[y].activationSum;

				outputLayer2[y].activationSum = placeHolder + num;

			}
		}

		for (int i = 0; i < numNextLayerNodes; i++){
			runNode(outputLayer2[i]);
		}

		FS = outputLayer2[0].output;
		RS = outputLayer2[1].output;
		LS = outputLayer2[2].output;

		float h1 = outputLayer2[0].output * (-1) * LSweight;
		float h2 = outputLayer2[1].output * RSweight;
		h = h1 + h2;

		// h = outputLayer2[0].output;

		float v1 = outputLayer2[2].output * (-1) * V1weight;
		float v2 = outputLayer2[3].output * V2weight;

		v = v1 + v2;

		// v = outputLayer2[2].output;
		handbrake = 0F;


        // set the output layer from the values we derived in the network

		outputLayer = new List<float>();
		outputLayer.Add(h);
		outputLayer.Add(v);
		outputLayer.Add(handbrake);
	}
}
