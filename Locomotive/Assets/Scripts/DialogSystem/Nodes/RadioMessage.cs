using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogX
{
	public class RadioMessage : Node
	{
		[Input]
		public bool input;
		[Output]
		public bool output;

		[TextArea(8, 3)]
		public string text = "";
		public AudioClip audioClip;



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
				bool inp_val = GetInputValue<bool>("input", input);

				return inp_val;
			}
			return null;
		}
	}
}
