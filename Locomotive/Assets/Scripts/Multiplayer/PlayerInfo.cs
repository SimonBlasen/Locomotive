using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private byte playerId = 255;

    public PlayerInfo()
    {
        
    }

    public byte ID
    {
        get
        {
            return playerId;
        }
        set
        {
            playerId = value;
        }
    }

    public float Ping
    {
        get; set;
    } = 0f;

    public bool IsConnected
    {
        get; set;
    } = false;
}
