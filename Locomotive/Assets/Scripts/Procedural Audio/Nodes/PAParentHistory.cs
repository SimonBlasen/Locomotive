using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcAudio
{
	public class PAParentHistory : Node
	{

		private float[] prev_outputs = new float[2048];
		private float[] prev_inputs = new float[2048];
		private List<float[]> add_prevs = new List<float[]>();
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

		protected float[] getLastAdditionals(int amount, int additional_index)
		{
			while (add_prevs.Count <= additional_index)
			{
				add_prevs.Add(new float[2048]);
			}

			float[] last_additionals = new float[amount];
			for (int i = 0; i < amount; i++)
			{
				int index = prev_index - i;
				if (index < 0)
				{
					index += add_prevs[additional_index].Length;
				}

				last_additionals[i] = add_prevs[additional_index][index];
			}

			return last_additionals;
		}

		protected void trackAdditionals(int additional_index, float val)
		{
			while (add_prevs.Count <= additional_index)
			{
				add_prevs.Add(new float[2048]);
			}

			add_prevs[additional_index][prev_index] = val;
		}
	}
}
