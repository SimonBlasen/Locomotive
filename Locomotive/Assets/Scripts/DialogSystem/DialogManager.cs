using DialogX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogManager : MonoBehaviour
{
    [Header("Dialogues")]
    [SerializeField]
    private DialogGraph[] dialogGraphs = null;

    [Space]

    [Header("References")]
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private Radio radio = null;

    private DialogGraph curGraph = null;
    private Node curNode = null;

    // Start is called before the first frame update
    void Start()
    {
        radio.DialogClosed += Radio_DialogClosed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerActivated(DialogTrigger dialogTrigger)
    {
        for (int g = 0; g < dialogGraphs.Length; g++)
        {
            DialogGraph graph = dialogGraphs[g];
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (typeof(StartNode).IsAssignableFrom(graph.nodes[i].GetType()))
                {
                    StartNode startNode = (StartNode)graph.nodes[i];
                    if (startNode.triggerType == dialogTrigger.TriggerType && startNode.triggerName == dialogTrigger.TriggerID)
                    {
                        curGraph = graph;
                        curNode = graph.nodes[i];
                        break;
                    }
                }
            }

            if (curGraph != null && curNode != null)
            {
                break;
            }
        }

        executeCurNode();
    }

    private void executeCurNode()
    {
        if (typeof(StartNode).IsAssignableFrom(curNode.GetType()))
        {
            Node nextNode = curNode.GetOutputPort("output").GetConnection(0).node;
            curNode = nextNode;
            executeCurNode();
        }
        if (typeof(RadioMessage).IsAssignableFrom(curNode.GetType()))
        {
            RadioMessage radioMessage = (RadioMessage)curNode;

            radio.ShowDialogue(radioMessage.text, radioMessage.audioClip);
        }
        if (typeof(Answer).IsAssignableFrom(curNode.GetType()))
        {
            Answer answer = (Answer)curNode;

            List<string> answers = new List<string>();
            if (answer.text0.Length > 0)
            {
                answers.Add(answer.text0);
                if (answer.text1.Length > 0)
                {
                    answers.Add(answer.text1);
                    if (answer.text2.Length > 0)
                    {
                        answers.Add(answer.text2);
                        if (answer.text3.Length > 0)
                        {
                            answers.Add(answer.text3);
                        }
                    }
                }
            }

            radio.ShowChoices(answers.ToArray());
        }
        if (typeof(End).IsAssignableFrom(curNode.GetType()))
        {
            curNode = null;
            curGraph = null;
            Debug.Log("Dialog finished");
        }
    }

    private void Radio_DialogClosed(int choiceIndex)
    {
        if (choiceIndex == -1)
        {
            Node nextNode = curNode.GetOutputPort("output").GetConnection(0).node;
            curNode = nextNode;
            executeCurNode();
        }
        else
        {
            Node nextNode = null;
            if (choiceIndex == 0)
            {
                nextNode = curNode.GetOutputPort("option0").GetConnection(0).node;
            }
            if (choiceIndex == 1)
            {
                nextNode = curNode.GetOutputPort("option1").GetConnection(0).node;
            }
            if (choiceIndex == 2)
            {
                nextNode = curNode.GetOutputPort("option2").GetConnection(0).node;
            }
            if (choiceIndex == 3)
            {
                nextNode = curNode.GetOutputPort("option3").GetConnection(0).node;
            }
            curNode = nextNode;
            executeCurNode();
        }
    }


    public Train Train
    {
        get
        {
            return train;
        }
    }
}
