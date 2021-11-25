using SappAnims;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum RadioSoundState
{
    IDLE, DIAL_IN, PLAYING, DIAL_OUT
}

public class Radio : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDialogue = null;
    [SerializeField]
    private RadioChoices radioChoices = null;
    [SerializeField]
    private AudioClip audioClipDialIn = null;
    [SerializeField]
    private AudioClip audioClipDialOut = null;
    [SerializeField]
    private AudioClip audioClipBackDropLoop = null;
    [SerializeField]
    private AudioSource audioSourceBackloop = null;

    private SappAnim textDialogueAnim = null;

    private float clearDialogueTextIn = 0f;

    [SerializeField]
    private AudioSource audioSource = null;

    public delegate void DialogClosedEvent(int choiceIndex);
    public event DialogClosedEvent DialogClosed;

    private float blockSelectionFor = 0f;
    private bool isTextShown = false;

    private RadioSoundState soundState = RadioSoundState.IDLE;
    private AudioClip audioClipToPlay = null;
    private string textToShow = "";

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

        if (soundState == RadioSoundState.DIAL_IN && audioSourceBackloop.isPlaying == false)
        {
            soundState = RadioSoundState.PLAYING;
            audioSourceBackloop.clip = audioClipBackDropLoop;
            audioSourceBackloop.loop = true;
            audioSourceBackloop.Play();

            blockSelectionFor = 0.2f;
            if (audioClipToPlay != null)
            {
                audioSource.clip = audioClipToPlay;
                audioSource.Play();
                audioClipToPlay = null;
            }
            if (textToShow.Length > 0)
            {
                textDialogueAnim.Text = textToShow;
                textToShow = "";
            }
        }
        if (soundState == RadioSoundState.PLAYING && audioSource.isPlaying == false)
        {

        }
        if (soundState == RadioSoundState.DIAL_OUT && audioSource.isPlaying == false)
        {
            soundState = RadioSoundState.IDLE;
        }
    }

    public void DialIn()
    {
        if (soundState == RadioSoundState.IDLE)
        {
            audioSourceBackloop.clip = audioClipDialIn;
            audioSourceBackloop.loop = false;
            audioSourceBackloop.Play();
            soundState = RadioSoundState.DIAL_IN;
        }
    }

    public void DialOut()
    {
        soundState = RadioSoundState.DIAL_OUT;
        audioSourceBackloop.Stop();
        audioSourceBackloop.loop = false;
        audioSourceBackloop.clip = audioClipDialOut;
        audioSourceBackloop.Play();
    }

    public void ShowDialogue(DialogueData dialogueData)
    {
        textDialogueAnim.Text = dialogueData.dialogueText;

        clearDialogueTextIn = 7f;
    }

    public void ShowDialogue(string text, AudioClip audioClip)
    {
        isTextShown = true;
        if (soundState == RadioSoundState.PLAYING)
        {
            blockSelectionFor = 0.2f;
            textDialogueAnim.Text = text;
            if (audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            clearDialogueTextIn = 0f;
        }
        else
        {
            blockSelectionFor = audioClipDialIn.length;
            textToShow = text;
            audioClipToPlay = audioClip;
        }



        //clearDialogueTextIn = 7f;
    }

    public void ShowChoices(string[] choices)
    {
        radioChoices.ShowChoices(choices);
    }
}
