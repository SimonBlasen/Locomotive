using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConnectInterface : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Network network;

    [Space]

    [SerializeField]
    private TMP_InputField inputIP;
    [SerializeField]
    private TMP_InputField inputPort;
    [SerializeField]
    private TMP_InputField inputPlayername;

    // Start is called before the first frame update
    void Start()
    {
        inputIP.text = "192.168.1.21";
        inputPort.text = "33000";
        inputPlayername.text = "Player 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonConnectClick()
    {
        //network.Connect(inputIP.text, Convert.ToInt32(inputPort.text), inputPlayername.text);
    }
}
