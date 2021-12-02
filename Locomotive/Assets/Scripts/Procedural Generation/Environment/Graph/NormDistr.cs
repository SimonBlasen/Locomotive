using Sappph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class NormDistr : Node
	{

		[Input]
		public float input;
		
		public float sigma;

		[Output]
		public float probability;

		private float randVal0 = 0f;
		private float randVal1 = 0f;


		[TextArea(8, 3)]
		public string info = "68% of all samples are between [input - sigma] and [input + sigma].";



		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "probability")
			{
				float inputVal = GetInputValue<float>("input", input);

				float val = Utils.NormalDistribution(inputVal, sigma, randVal0, randVal1);

				return val;
			}
			return null;
		}

		public void ComputeRandom()
		{
			randVal0 = UnityEngine.Random.Range(0f, 1f);
			randVal1 = UnityEngine.Random.Range(0f, 1f);
		}
	}
}
