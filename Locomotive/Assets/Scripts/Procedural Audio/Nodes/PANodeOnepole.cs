using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeOnepole : PAParentHistory
{

	[Input]
	public float[] input;

	[Output]
	public float[] output;

	public bool isLowPass = false;
	public bool passthrough = false;
	public float lp_fCut;
	public float lp_fSampling;
	public float hp_fCut;
	public float hp_fSampling;

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
			output_vals = new float[input_vals.Length];

			for (int i = 0; i < output_vals.Length; i++)
			{
				float a0 = 0f;
				float a1 = 0f;
				float b1 = 0f;

				if (isLowPass)
				{
					float w = 2f * lp_fSampling;
					float fCut = lp_fCut * 2f * Mathf.PI;
					float norm = 1f / (fCut + w);
					b1 = (w - fCut) * norm;
					a0 = fCut * norm;
					a1 = a0;
				}
                else
				{
					float w = 2f * hp_fSampling;
					float fCut = hp_fCut * 2f * Mathf.PI;
					float norm = 1f / (fCut + w);
					a0 = w * norm;
					a1 = -a0;
					b1 = (w - fCut) * norm;
				}


				float inp = input_vals[i];
				float inp_1 = getLastInputs(1)[0];
				float out_1 = getLastOutputs(1)[0];


				output_vals[i] = inp * a0 + inp_1 * a1 + out_1 * b1;

				if (passthrough)
                {
					output_vals[i] = inp;

				}


				//float val_y = inp * lowpass_a + (1f - lowpass_a) * getLastOutputs(1)[0];


				trackInputOutput(input_vals[i], output_vals[i]);
			}

			return output_vals;
		}
		return null;
	}
}