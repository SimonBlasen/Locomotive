using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ProcAudio
{
	public class PAParentGenerator : PAParentTimedependend
	{

		[HideInInspector]
		public int sampleSize;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}
	}
}