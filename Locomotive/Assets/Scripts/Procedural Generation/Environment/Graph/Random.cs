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

				float val = UnityEngine.Random.Range(inputMin, inputMax);

				return val;
			}
			return null;
		}
	}
}
