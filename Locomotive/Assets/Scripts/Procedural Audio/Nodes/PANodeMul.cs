using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeMul : Node
{

	[Input]
	public float[] a;

	[Input]
	public float[] b;

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
			float[] input_a = GetInputValue<float[]>("a", a);
			float[] input_b = GetInputValue<float[]>("b", b);
			vals = new float[input_a.Length];

			for (int i = 0; i < vals.Length; i++)
			{
				vals[i] = input_a[i] * input_b[i];

			}

			return vals;
		}
		return null;
	}
}