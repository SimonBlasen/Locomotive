using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Add : Node
	{

		[Input]
		public float a;
		[Input]
		public float b;

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
				float inp_a = GetInputValue<float>("a", a);
				float inp_b = GetInputValue<float>("b", b);

				return inp_a + inp_b;
			}
			return null;
		}
	}
}
