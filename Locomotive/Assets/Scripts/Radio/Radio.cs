using SappAnims;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDialogue = null;

    private SappAnim textDialogueAnim = null;

    private float clearDialogueTextIn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textDialogueAnim = textDialogue.GetComponent<SappAnim>();
        textDialogue.text = "";
        textDialogueAnim.Text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (clearDialogueTextIn > 0f)
        {
            clearDialogueTextIn -= Time.deltaTime;

            if (clearDialogueTextIn <= 0f)
            {
                textDialogue.text = "";
                textDialogueAnim.Text = "";
            }
        }
    }

    public void ShowDialogue(DialogueData dialogueData)
    {
        textDialogueAnim.Text = dialogueData.dialogueText;

        clearDialogueTextIn = 7f;
    }
}
