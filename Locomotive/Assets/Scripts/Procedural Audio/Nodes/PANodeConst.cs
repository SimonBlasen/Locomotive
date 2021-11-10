using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeConst : PAParentGenerator
{
	public float constValue;

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
			float[] output_vals;
			output_vals = new float[sampleSize];

			for (int i = 0; i < output_vals.Length; i++)
			{
				output_vals[i] = constValue;
			}

			return output_vals;
		}
		return null;
	}
}