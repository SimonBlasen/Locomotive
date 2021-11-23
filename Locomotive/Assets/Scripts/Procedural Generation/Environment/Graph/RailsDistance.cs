using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class RailsDistance : Node
	{
		[HideInInspector]
		public float distanceFromRail;

		[Output]
		public float distance;

		[TextArea(8, 3)]
		//public string info = "Distance is the closest distance to the next rails in meters";
		public string info = "Does work now. Puts out the distance to the next rails in meters";


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "distance")
			{
				float distanceVal = distanceFromRail;

				//return 100f;
				return distanceVal;
			}
			return null;
		}
	}
}
