using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcEnvXNode
{
	public class Texture : Node
	{

		public Texture2D texture;

		[Space]

		public float tilingX = 1f;
		public float tilingY = 1f;

		[Space]

		[Output]
		public float scalar;
		[Output]
		public float out_r;
		[Output]
		public float out_g;
		[Output]
		public float out_b;

		[TextArea(8, 3)]
		public string info = "A tiling of 1 means, that the whole texture is fitted on 100meters.\n With 0.1 it is fitted to 1000 meters, tiling=10 fits the whole texture to 10 meters.";


		[HideInInspector]
		public Vector2 gridPos;


		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			Color color = texture.GetPixel((int)((gridPos.x * tilingX * texture.width) / 100f), (int)((gridPos.y * tilingY * texture.height) / 100f));
			if (port.fieldName == "scalar")
			{
				return (color.r + color.g + color.b) / 3f;
			}
			if (port.fieldName == "out_r")
			{
				return color.r;
			}
			if (port.fieldName == "out_g")
			{
				return color.g;
			}
			if (port.fieldName == "out_b")
			{
				return color.b;
			}
			return null;
		}
	}
}
