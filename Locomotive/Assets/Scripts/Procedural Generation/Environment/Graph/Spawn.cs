using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Spawn : Node
	{

		[Input]
		public float probability;

		public float cellSize;

		public float randomInCell;


		[Input]
		public ObjectVariantData objectVariant0;
		[Input]
		public ObjectVariantData objectVariant1;
		[Input]
		public ObjectVariantData objectVariant2;
		[Input]
		public ObjectVariantData objectVariant3;
		[Input]
		public ObjectVariantData objectVariant4;
		[Input]
		public ObjectVariantData objectVariant5;
		[Input]
		public ObjectVariantData objectVariant6;
		[Input]
		public ObjectVariantData objectVariant7;
		[Input]
		public ObjectVariantData objectVariant8;
		[Input]
		public ObjectVariantData objectVariant9;
		[Input]
		public ObjectVariantData objectVariant10;
		[Input]
		public ObjectVariantData objectVariant11;
		[Input]
		public ObjectVariantData objectVariant12;
		[Input]
		public ObjectVariantData objectVariant13;
		[Input]
		public ObjectVariantData objectVariant14;

		[Output, HideInInspector]
		public float output;
		[Output, HideInInspector]
		public ObjectVariantData[] outputObjectVariants;


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
				float input_val = GetInputValue<float>("probability", probability);

				return input_val;
			}
			else if (port.fieldName == "outputObjectVariants")
			{
				//ObjectVariantData[] ovds = GetInputValue<ObjectVariantData[]>("objectVariants", objectVariants);
				ObjectVariantData ovd0 = GetInputValue<ObjectVariantData>("objectVariant0", objectVariant0);
				ObjectVariantData ovd1 = GetInputValue<ObjectVariantData>("objectVariant1", objectVariant1);
				ObjectVariantData ovd2 = GetInputValue<ObjectVariantData>("objectVariant2", objectVariant2);
				ObjectVariantData ovd3 = GetInputValue<ObjectVariantData>("objectVariant3", objectVariant3);
				ObjectVariantData ovd4 = GetInputValue<ObjectVariantData>("objectVariant4", objectVariant4);
				ObjectVariantData ovd5 = GetInputValue<ObjectVariantData>("objectVariant5", objectVariant5);
				ObjectVariantData ovd6 = GetInputValue<ObjectVariantData>("objectVariant6", objectVariant6);
				ObjectVariantData ovd7 = GetInputValue<ObjectVariantData>("objectVariant7", objectVariant7);
				ObjectVariantData ovd8 = GetInputValue<ObjectVariantData>("objectVariant8", objectVariant8);
				ObjectVariantData ovd9 = GetInputValue<ObjectVariantData>("objectVariant9", objectVariant9);
				ObjectVariantData ovd10 = GetInputValue<ObjectVariantData>("objectVariant10", objectVariant10);
				ObjectVariantData ovd11 = GetInputValue<ObjectVariantData>("objectVariant11", objectVariant11);
				ObjectVariantData ovd12 = GetInputValue<ObjectVariantData>("objectVariant12", objectVariant12);
				ObjectVariantData ovd13 = GetInputValue<ObjectVariantData>("objectVariant13", objectVariant13);
				ObjectVariantData ovd14 = GetInputValue<ObjectVariantData>("objectVariant14", objectVariant14);

				List<ObjectVariantData> ovds = new List<ObjectVariantData>();
				ovds.Add(ovd0);
				ovds.Add(ovd1);
				ovds.Add(ovd2);
				ovds.Add(ovd3);
				ovds.Add(ovd4);
				ovds.Add(ovd5);
				ovds.Add(ovd6);
				ovds.Add(ovd7);
				ovds.Add(ovd8);
				ovds.Add(ovd9);
				ovds.Add(ovd10);
				ovds.Add(ovd11);
				ovds.Add(ovd12);
				ovds.Add(ovd13);
				ovds.Add(ovd14);

				for (int i = 0; i < ovds.Count; i++)
                {
					if (ovds[i] == null || ovds[i].prefab == null)
                    {
						ovds.RemoveAt(i);
						i--;
                    }
                }




				return ovds.ToArray();
			}
			return null;
		}
	}
}
