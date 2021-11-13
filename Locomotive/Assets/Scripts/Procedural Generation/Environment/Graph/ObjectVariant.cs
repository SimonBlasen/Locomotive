using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class ObjectVariant : Node
	{

		public GameObject prefab;

		[Space]

		[Input]
		public float occurence = 1f;

		[Space]

		[Input]
		public float scaleX = 1f;
		[Input]
		public float scaleY = 1f;
		[Input]
		public float scaleZ = 1f;

		[Space]

		[Input]
		public float rotY = 0f;
		[Input]
		public float adjustToSlope = 0f;
		[Input]
		public bool randomRot = false;

		[Space]

		[Input]
		public float offsetY = 0f;

		[Output]
		public ObjectVariantData output;


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
				ObjectVariantData ovd = new ObjectVariantData();
				ovd.prefab = prefab;
				ovd.occurence = GetInputValue<float>("occurence", occurence);
				ovd.scaleX = GetInputValue<float>("scaleX", scaleX);
				ovd.scaleY = GetInputValue<float>("scaleY", scaleY);
				ovd.scaleZ = GetInputValue<float>("scaleZ", scaleZ);
				ovd.adjustToSlope = GetInputValue<float>("adjustToSlope", adjustToSlope);
				ovd.rotY = GetInputValue<float>("rotY", rotY);
				ovd.randomRot = GetInputValue<bool>("randomRot", randomRot);
				ovd.offsetY = GetInputValue<float>("offsetY", offsetY);

				return ovd;
			}
			return null;
		}
	}


	[Serializable]
	public class ObjectVariantData
    {
		public GameObject prefab;
		public float occurence = 1f;
		public float scaleX = 1f;
		public float scaleY = 1f;
		public float scaleZ = 1f;
		public float adjustToSlope = 0f;
		public float rotY = 0f;
		public bool randomRot = false;
		public float offsetY = 0f;
	}
}




