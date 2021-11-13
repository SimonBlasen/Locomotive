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

				float val = Utils.NormalDistribution(inputVal, sigma);

				return val;
			}
			return null;
		}
	}
}
