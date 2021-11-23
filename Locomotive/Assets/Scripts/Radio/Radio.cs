using SappAnims;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDialogue = null;
    [SerializeField]
    private RadioChoices radioChoices = null;

    private SappAnim textDialogueAnim = null;

    private float clearDialogueTextIn = 0f;

    [SerializeField]
    private AudioSource audioSource = null;

    public delegate void DialogClosedEvent(int choiceIndex);
    public event DialogClosedEvent DialogClosed;

    private float blockSelectionFor = 0f;
    private bool isTextShown = false;

    // Start is called before the first frame update
    void Start()
    {
        textDialogueAnim = textDialogue.GetComponent<SappAnim>();
        textDialogue.text = "";
        textDialogueAnim.Text = "";
        isTextShown = false;

        radioChoices.SelectChoice += RadioChoices_SelectChoice;
    }

    private void RadioChoices_SelectChoice(int choiceIndex)
    {
        DialogClosed?.Invoke(choiceIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (blockSelectionFor > 0f)
        {
            blockSelectionFor -= Time.deltaTime;
        }

        if (clearDialogueTextIn > 0f)
        {
            clearDialogueTextIn -= Time.deltaTime;

            if (clearDialogueTextIn <= 0f)
            {
                textDialogue.text = "";
                textDialogueAnim.Text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (blockSelectionFor <= 0f && isTextShown)
            {
                textDialogue.text = "";
                textDialogueAnim.Text = "";
                isTextShown = false;

                DialogClosed?.Invoke(-1);
            }
        }
    }

    public void ShowDialogue(DialogueData dialogueData)
    {
        textDialogueAnim.Text = dialogueData.dialogueText;

        clearDialogueTextIn = 7f;
    }

    public void ShowDialogue(string text, AudioClip audioClip)
    {
        isTextShown = true;
        blockSelectionFor = 0.2f;
        textDialogueAnim.Text = text;
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        clearDialogueTextIn = 0f;

        //clearDialogueTextIn = 7f;
    }

    public void ShowChoices(string[] choices)
    {
        radioChoices.ShowChoices(choices);
    }
}
