using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Clamp : Node
	{

		[Input]
		public float input;
		[Input]
		public float min;
		[Input]
		public float max;

		[Output]
		public float output;


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
				float input_val = GetInputValue<float>("input", input);
				float clamp_min = GetInputValue<float>("min", min);
				float clamp_max = GetInputValue<float>("max", max);

				float val = Mathf.Clamp(input_val, clamp_min, clamp_max);

				return val;
			}
			return null;
		}
	}
}
