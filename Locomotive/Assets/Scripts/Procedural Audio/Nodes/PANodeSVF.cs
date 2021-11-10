using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeSVF : PAParentHistory
{

	[Input]
	public float[] input;

	//[Output]
	//public float[] output;


	[Input]
	public float[] frequencyControl;
	[Input]
	public float[] qControl;

	[Output]
	public float[] lowpass;
	[Output]
	public float[] highpass;
	[Output]
	public float[] bandpass;
	[Output]
	public float[] notch;

	private float[] lastInput = null;
	private float[] result_lowpass;
	private float[] result_highpass;
	private float[] result_bandpass;
	private float[] result_notch;


	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		float[] input_vals = GetInputValue<float[]>("input", input);

		bool isInputNovel = isInputUnequal(input_vals);
		if (isInputNovel)
		{
			computeResults(input_vals);
		}

		if (port.fieldName == "lowpass")
		{
			return result_lowpass;
		}
		else if (port.fieldName == "highpass")
		{
			return result_highpass;
		}
		else if (port.fieldName == "bandpass")
		{
			return result_bandpass;
		}
		else if (port.fieldName == "notch")
		{
			return result_notch;
		}
		return null;
	}


	private void computeResults(float[] inputVals)
	{
		result_lowpass = new float[inputVals.Length];
		result_highpass = new float[inputVals.Length];
		result_bandpass = new float[inputVals.Length];
		result_notch = new float[inputVals.Length];

		for (int i = 0; i < inputVals.Length; i++)
		{
			float inp = inputVals[i];

			float[] f1 = GetInputValue<float[]>("frequencyControl", frequencyControl);
			float[] q1 = GetInputValue<float[]>("qControl", qControl);

			result_lowpass[i] = getLastAdditionals(1, 0)[0] + f1[i] * getLastAdditionals(1, 2)[0];
			result_highpass[i] = inp - result_lowpass[i] - q1[i] * getLastAdditionals(1, 2)[0];
			result_bandpass[i] = f1[i] * result_highpass[i] + getLastAdditionals(1, 2)[0];
			result_notch[i] = result_highpass[i] + result_lowpass[i];



			trackInputOutput(inp, result_notch[i]);
			trackAdditionals(0, result_lowpass[i]);
			trackAdditionals(2, result_bandpass[i]);

		}
	}


	private bool isInputUnequal(float[] newInput)
    {
		if (lastInput == null || lastInput.Length != newInput.Length)
        {
			lastInput = new float[newInput.Length];

			for (int i = 0; i < lastInput.Length; i++)
            {
				lastInput[i] = newInput[i];
            }

			return true;
		}
        else
		{
			bool areUnequal = false;
			for (int i = 0; i < lastInput.Length; i++)
			{
				if (lastInput[i] != newInput[i])
                {
					areUnequal = true;
					break;
				}
			}

			if (areUnequal)
			{
				for (int i = 0; i < lastInput.Length; i++)
				{
					lastInput[i] = newInput[i];
				}
				return true;
			}
            else
            {
				return false;
            }
		}
    }
}