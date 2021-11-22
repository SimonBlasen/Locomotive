using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class YHeight : Node
	{
		[HideInInspector]
		public float yHeightVal;

		[Output]
		public float yHeight;

		[TextArea(8, 3)]
		public string info = "The absolute height of the sample (in meters)";


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "yHeight")
			{
				float outVal = yHeightVal;

				return outVal;
			}

			return null;
		}
	}
}
