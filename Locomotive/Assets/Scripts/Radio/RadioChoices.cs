using SappAnims;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioChoices : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] textsOptions = null;
    [SerializeField]
    private SappAnim choosePanel = null;
    [SerializeField]
    private SappAnim choosePanelAlpha = null;
    [SerializeField]
    private Transform[] choicesPanelPositions = null;

    public delegate void SelectChoiceEvent(int choiceIndex);
    public event SelectChoiceEvent SelectChoice;


    private int currentSelection = 0;
    private int choicesAmount = 0;

    private float blockSelectionFor = 0f;

    // Start is called before the first frame update
    void Start()
    {
        choosePanelAlpha.Alpha = 0f;
        choosePanelAlpha.Visible = false;
        ClearChoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (blockSelectionFor > 0f)
        {
            blockSelectionFor -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentSelection--;
            if (currentSelection < 0)
            {
                currentSelection = 0;
            }
            refreshChoicePanel();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentSelection++;
            if (currentSelection >= choicesAmount)
            {
                currentSelection = choicesAmount - 1;
            }
            refreshChoicePanel();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (blockSelectionFor <= 0f && choicesAmount > 0)
            {
                SelectChoice?.Invoke(currentSelection);
                ClearChoice();
            }
        }
    }

    private void refreshChoicePanel()
    {
        if (currentSelection >= 0 && currentSelection < choicesPanelPositions.Length)
        {
            choosePanel.LocalPosition = choicesPanelPositions[currentSelection].localPosition;
        }
    }

    public void ClearChoice()
    {
        for (int i = 0; i < textsOptions.Length; i++)
        {
            textsOptions[i].text = "";
        }
        choosePanelAlpha.Visible = false;
        choicesAmount = 0;
    }

    public void ShowChoices(string[] choices)
    {
        blockSelectionFor = 0.2f;
        currentSelection = 0;

        choosePanel.transform.localPosition = choicesPanelPositions[currentSelection].localPosition;
        refreshChoicePanel();
        choosePanelAlpha.Visible = true;
        choicesAmount = choices.Length;
        for (int i = 0; i < choices.Length; i++)
        {
            if (i < textsOptions.Length)
            {
                textsOptions[i].text = choices[i];
            }
        }
        for (int i = choices.Length; i < textsOptions.Length; i++)
        {
            textsOptions[i].text = "";
        }
    }
}
