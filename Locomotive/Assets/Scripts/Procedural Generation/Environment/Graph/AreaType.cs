using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class AreaType : Node
	{
		[HideInInspector]
		public float[] areaWeights = new float[5];

		[Output]
		public ProcAreaType curArea;
		[Output]
		public float wMountains;
		[Output]
		public float wSnow;
		[Output]
		public float wDesert;
		[Output]
		public float wPlane;
		[Output]
		public float wForrest;


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			if (areaWeights == null || areaWeights.Length < 5)
            {
				areaWeights = new float[5];
			}

			if (port.fieldName == "curArea")
			{
				float maxWeight = 0f;
				int maxIndex = -1;
				for (int i = 0; i < areaWeights.Length; i++)
                {
					if (areaWeights[i] > maxWeight)
                    {
						maxWeight = areaWeights[i];
						maxIndex = i;
                    }
                }

				ProcAreaType curAreaType = (ProcAreaType)maxIndex;

				return curAreaType;
			}
			else if (port.fieldName == "wMountains")
			{
				return areaWeights[(int)ProcAreaType.MOUNTAINS];
			}
			else if (port.fieldName == "wSnow")
			{
				return areaWeights[(int)ProcAreaType.SNOW_MOUNTAINS];
			}
			else if (port.fieldName == "wDesert")
			{
				return areaWeights[(int)ProcAreaType.DESERT];
			}
			else if (port.fieldName == "wPlane")
			{
				return areaWeights[(int)ProcAreaType.PLANE];
			}
			else if (port.fieldName == "wForrest")
			{
				return areaWeights[(int)ProcAreaType.FORREST];
			}
			return null;
		}
	}
}
