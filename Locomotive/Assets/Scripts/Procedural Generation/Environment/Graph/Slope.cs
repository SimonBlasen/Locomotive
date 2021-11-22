using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Slope : Node
	{
		[HideInInspector]
		public float slopeAngle;

		[Output]
		public float angle;
		[Output]
		public float cosAngle;

		[TextArea(8, 3)]
		public string info = "Angle is zero, if the surface is flat. It is 90, if the surface is a wall. The cosAngle is equal to 1, if the surface is flat, and 0 if the surface is a wall (90 degrees)";


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "angle")
			{
				float outAngle = slopeAngle;

				return outAngle;
			}
			else if (port.fieldName == "cosAngle")
			{
				float outCosine = Mathf.Cos(slopeAngle * Mathf.Deg2Rad);

				return outCosine;
			}
			return null;
		}
	}
}
