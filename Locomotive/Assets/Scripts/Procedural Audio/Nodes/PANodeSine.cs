using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeSine : PAParentGenerator
{
	[Output]
	public float[] noiseOutput;

	public double frequency = 1f;

	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "noiseOutput")
		{
			float[] vals = new float[sampleSize];
			for (int i = 0; i < sampleSize; i++)
            {
				vals[i] = (float)System.Math.Sin(times[i] * frequency) * 0.5f + 0.5f;

			}

			return vals;
		}
		return null;
	}
}