using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcAudio
{
	public class PAParentTimedependend : Node
	{

		[HideInInspector]
		public double[] times;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}
	}
}