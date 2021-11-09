using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeWhitenoise : PANodeGenerator
{

	[Output]
	public float[] noiseOutput;

	public float strength = 0f;

	private System.Random rand = new System.Random();

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
				vals[i] = ((float)(rand.NextDouble() * 2.0 - 1.0 + 0f)) * strength;
			}
			//return GetInputValue<float>("a", a);
			return vals;
		}
		return null;
	}
}