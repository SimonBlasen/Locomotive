using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class CustomCurve : Node
	{
		[Input]
		public float input;

		public AnimationCurve curve;

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
				float inp_val = GetInputValue<float>("input", input);

				float eval = curve.Evaluate(inp_val);

				return eval;
			}

			return null;
		}
	}
}
