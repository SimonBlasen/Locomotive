using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeSVF : PAParentHistory
{

	[Input]
	public float[] input;

	//[Output]
	//public float[] output;


	public float lowpass_a;

	[Input]
	public float fs;
	[Input]
	public float fc;
	[Input]
	public float res;
	[Input]
	public float drive;
	[Input]
	public float freq;
	[Input]
	public float damp;

	[Output]
	public float[] notch;


	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "notch")
		{
			float[] output_vals;
			float[] input_vals = GetInputValue<float[]>("input", input);
			output_vals = new float[input_vals.Length];

			for (int i = 0; i < output_vals.Length; i++)
			{
				float inp = input_vals[i];


				float val_y = inp * lowpass_a + (1f - lowpass_a) * getLastOutputs(1)[0];

				output_vals[i] = val_y;

				trackInputOutput(input_vals[i], output_vals[i]);
			}

			return output_vals;
		}
		return null;
	}
}