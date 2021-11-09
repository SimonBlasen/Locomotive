using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeSVF : Node
{

	[Input]
	public float[] input;

	//[Output]
	//public float[] output;


	public float lowpass_a;

	public float fs;
	public float fc;
	public float res;
	public float drive;
	public float freq;
	public float damp;

	[Output]
	public float[] notch;

	private float[] prev_outputs = new float[2048];
	private float[] prev_inputs = new float[2048];
	private int prev_index = 0;

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


				float val_y = inp * lowpass_a - (1f - lowpass_a) * getLastOutputs(1)[0];

				output_vals[i] = val_y;

				trackInputOutput(input_vals[i], output_vals[i]);
			}

			return output_vals;
		}
		return null;
	}

	private void trackInputOutput(float inputVal, float outputVal)
    {
		prev_index++;
		prev_index = prev_index % prev_outputs.Length;
		prev_outputs[prev_index] = outputVal;
		prev_inputs[prev_index] = inputVal;
    }

	public float[] getLastOutputs(int amount)
    {
		float[] last_outputs = new float[amount];
		for (int i = 0; i < amount; i++)
        {
			int index = prev_index - i;
			if (index < 0)
            {
				index += prev_outputs.Length;
            }

			last_outputs[i] = prev_outputs[index];
        }

		return last_outputs;
	}

	public float[] getLastInputs(int amount)
	{
		float[] last_inputs = new float[amount];
		for (int i = 0; i < amount; i++)
		{
			int index = prev_index - i;
			if (index < 0)
			{
				index += prev_inputs.Length;
			}

			last_inputs[i] = prev_inputs[index];
		}

		return last_inputs;
	}
}