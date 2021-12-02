using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Random : Node
	{

		[Input]
		public float minVal;
		[Input]
		public float maxVal;

		[Output]
		public float random;

		private float randVal = 0f;

		[TextArea(8, 3)]
		public string info = "Completely random value between min and max";



		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "random")
			{
				float inputMin = GetInputValue<float>("minVal", minVal);
				float inputMax = GetInputValue<float>("maxVal", maxVal);

				float val = Mathf.Lerp(inputMin, inputMax, randVal);
				//float val = UnityEngine.Random.Range(inputMin, inputMax);

				return val;
			}
			return null;
		}

		public void ComputeRandom()
		{
			float val = UnityEngine.Random.Range(0f, 1f);
			randVal = val;
		}
	}
}
