using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeOnepoleMAX : PAParentHistory
{

	[Input]
	public float[] input;

	[Output]
	public float[] output;

	[Input]
	public float[] cf;

	[TextArea(8, 3)]
	public string info = "cf ist the cutoff frequency of the filter expressed in radians. The values for cf lie in the range [-1, 0]. This produces a single-pole lowpass filter with a 6dB/octave attenuation.";

	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "output")
		{
			float[] output_vals;
			float[] input_vals = GetInputValue<float[]>("input", input);
			float[] cf_inputs = GetInputValue<float[]>("cf", cf);
			output_vals = new float[input_vals.Length];

			for (int i = 0; i < output_vals.Length; i++)
			{
				float inp = input_vals[i];
				float inp_1 = getLastInputs(1)[0];


				output_vals[i] = inp_1 + cf_inputs[i] * (inp - inp_1);


				trackInputOutput(input_vals[i], output_vals[i]);
			}

			return output_vals;
		}
		return null;
	}
}