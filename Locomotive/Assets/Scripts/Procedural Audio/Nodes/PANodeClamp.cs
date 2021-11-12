using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeClamp : Node
{

	[Input]
	public float[] input;

	public float clamp_min;

	public float clamp_max;

	[Output]
	public float[] output;


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
			float[] vals;
			float[] input_vals = GetInputValue<float[]>("input", input);
			vals = new float[input_vals.Length];

			for (int i = 0; i < vals.Length; i++)
			{
				vals[i] = Mathf.Clamp(input_vals[i], clamp_min, clamp_max);

			}

			return vals;
		}
		return null;
	}
}