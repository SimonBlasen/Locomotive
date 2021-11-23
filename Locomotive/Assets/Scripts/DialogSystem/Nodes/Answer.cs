using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogX
{
	public class Answer : Node
	{
		[Input]
		public bool input;

		[Space]


		[TextArea(8, 3)]
		public string topText = "";

		[Space]

		[Output]
		public bool option0;
		[TextArea(8, 3)]
		public string text0 = "";
		public AudioClip audioClip0;

		[Space]

		[Output]
		public bool option1;
		[TextArea(8, 3)]
		public string text1 = "";
		public AudioClip audioClip1;

		[Space]

		[Output]
		public bool option2;
		[TextArea(8, 3)]
		public string text2 = "";
		public AudioClip audioClip2;

		[Space]

		[Output]
		public bool option3;
		[TextArea(8, 3)]
		public string text3 = "";
		public AudioClip audioClip3;



		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			bool inp_val = GetInputValue<bool>("input", input);

			return inp_val;
			/*if (port.fieldName == "option0")
			{
				bool inp_val = GetInputValue<bool>("input", input);

				return inp_val;
			}*/
			return null;
		}
	}
}