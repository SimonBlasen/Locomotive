using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class PANodeOutput : Node
{

	[Input]
	public float[] finalAudio;
	[Output]
	public float[] audioOutput;

	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "audioOutput")
		{
			return GetInputValue<float[]>("finalAudio", finalAudio);
		}
		return null;
	}
}