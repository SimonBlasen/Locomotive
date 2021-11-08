using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogues", menuName = "ScriptableObjects/Dialogues", order = 1)]
public class ScrDialogues : ScriptableObject
{
    public DialogueData[] dialogues;

    /*private static ScrDialogues inst = null;
    public static ScrDialogues Inst
    {
        get
        {
            if (inst == null)
            {
                inst = Resources.Load<ScrDialogues>("Dialogues");
            }

            return inst;
        }
    }*/
}


[System.Serializable]
public class DialogueData
{
    public string name = "";

    [FMODUnity.EventRef]
    public string fmodEventAmbientSound;

    [TextArea(3, 10)]
    public string dialogueText = "";
}