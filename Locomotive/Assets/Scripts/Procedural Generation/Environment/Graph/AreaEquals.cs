using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class AreaEquals : Node
	{

		[Input]
		public ProcAreaType a;
		[Input]
		public ProcAreaType b;

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
				ProcAreaType inp_a = GetInputValue<ProcAreaType>("a", a);
				ProcAreaType inp_b = GetInputValue<ProcAreaType>("b", b);

				return (inp_a == inp_b) ? 1f : 0f;
			}
			return null;
		}
	}
}
