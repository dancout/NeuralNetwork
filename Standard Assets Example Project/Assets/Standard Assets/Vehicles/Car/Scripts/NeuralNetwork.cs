using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour {

	public List<float> inputLayer = new List<float>(); // switch inputs
	public List<float> outputLayer = new List<float>(); // output values used for controlling the car

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// input layer should already be set from ComputeValues.cs
		// the below values are set as defaults. IE, if no switches are on, then just drive straight forward and slant a little to the right.
		float h = 0.1f;
		float v = 0.2F;
		float handbrake = 0;

		// Right Collision
		if(inputLayer.IndexOf(1) > 0) {
        	h = -0.5F;
        	v = 1;
        	handbrake = 0;
        }

        // Front Collision
        if(inputLayer.IndexOf(0) > 0){
        	h = -0.2F;
          	v = -1;
            handbrake = 0;
        }
		
		// Left Collision
		if(inputLayer.IndexOf(2) > 0) {
        	h = 0.5F;
        	v = 0.1F;
        	handbrake = 0;
        }

		outputLayer = new List<float>();
		outputLayer.Add(h);
		outputLayer.Add(v);
		outputLayer.Add(handbrake);
	}
}
