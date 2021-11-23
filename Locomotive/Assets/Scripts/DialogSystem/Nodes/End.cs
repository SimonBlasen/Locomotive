using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogX
{
	public class End : Node
	{
		[Input]
		public bool input;


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return null;
		}
	}
}
