using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcAudio
{
	public class PANodeDisplayCurve : Node
	{

		[Input]
		public float[] input;

		[Output]
		public float[] computeOutput;

		public AnimationCurve curve;

		private Keyframe[] keyframes;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

			keyframes = new Keyframe[2048];
			curve = new AnimationCurve(keyframes);

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "computeOutput")
			{
				float[] output_vals;
				float[] input_vals = GetInputValue<float[]>("input", input);
				output_vals = new float[input_vals.Length];

				for (int i = 0; i < input_vals.Length; i++)
				{
					output_vals[i] = input_vals[i];

					keyframes[i].time = i;
					keyframes[i].value = input_vals[i];
				}

				curve.keys = keyframes;

				return output_vals;
			}
			return null;
		}
	}
}