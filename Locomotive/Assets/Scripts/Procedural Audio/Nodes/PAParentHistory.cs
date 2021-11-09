using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PAParentHistory : Node
{

	private float[] prev_outputs = new float[2048];
	private float[] prev_inputs = new float[2048];
	private int prev_index = 0;

	private int sanity_index_check_counter = 0;

	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}



	protected void trackInputOutput(float inputVal, float outputVal)
	{
		sanity_index_check_counter = 0;
		prev_index++;
		prev_index = prev_index % prev_outputs.Length;
		prev_outputs[prev_index] = outputVal;
		prev_inputs[prev_index] = inputVal;
	}

	protected float[] getLastOutputs(int amount)
	{
		sanity_index_check_counter++;
		if (sanity_index_check_counter > 100)
		{
			Debug.LogError("History node does not track output/input");
		}

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

	protected float[] getLastInputs(int amount)
	{
		sanity_index_check_counter++;
		if (sanity_index_check_counter > 100)
		{
			Debug.LogError("History node does not track output/input");
		}

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