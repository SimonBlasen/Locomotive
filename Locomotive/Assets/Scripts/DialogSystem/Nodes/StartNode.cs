using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogX
{
	public enum TriggerType
    {
		DRIVE_POINT, SEE_STATUE, 
    }


	public class StartNode : Node
	{
		[Output]
		public bool output;

		[Space]
		public TriggerType triggerType;
		public string triggerName;


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
				return false;
			}
			return null;
		}
	}
}
