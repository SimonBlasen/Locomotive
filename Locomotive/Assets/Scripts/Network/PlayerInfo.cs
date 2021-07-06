using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerInfo
{
    public string playername;
    public byte id;
    public int skin = 0;
    public int horn = 0;
    public bool isInGoal = false;
    public byte playerLevel = 0;
    public byte team = 0;
    public int eloPoints = 0;

    public byte[] customSkinPngBytes = null;
    public List<int> customSkinReceivedIndices = new List<int>();
    public string customSkinMeta = "";
    public Color customSkinMainColor = Color.white;

    public bool CustomSkinCompletelyReceived
    {
        get
        {
            if (skin >= 0)
            {
                return true;
            }
            else
            {
                if (customSkinPngBytes == null)
                {
                    return false;
                }
                else
                {
                    int toReceivePackages = ((customSkinPngBytes.Length - 1) / 800) + 1;

                    return customSkinReceivedIndices.Count >= toReceivePackages && customSkinMeta.Length > 0;
                }
            }
        }
    }

    public byte[] ToAdditionalBytes()
    {
        List<byte> bytes = new List<byte>();

        byte[] nameBytes = Encoding.UTF8.GetBytes(playername);

        bytes.Add((byte)(nameBytes.Length >> 24));
        bytes.Add((byte)(nameBytes.Length >> 16));
        bytes.Add((byte)(nameBytes.Length >> 8));
        bytes.Add((byte)(nameBytes.Length));
        bytes.AddRange(nameBytes);


        bytes.Add((byte)(skin >> 24));
        bytes.Add((byte)(skin >> 16));
        bytes.Add((byte)(skin >> 8));
        bytes.Add((byte)(skin));
        bytes.Add((byte)(horn >> 24));
        bytes.Add((byte)(horn >> 16));
        bytes.Add((byte)(horn >> 8));
        bytes.Add((byte)(horn));
        bytes.Add(playerLevel);
        bytes.Add((byte)(eloPoints >> 24));
        bytes.Add((byte)(eloPoints >> 16));
        bytes.Add((byte)(eloPoints >> 8));
        bytes.Add((byte)(eloPoints));

        return bytes.ToArray();
    }

    public void FromAdditionalBytes(byte[] bytes)
    {
        int nameLen = (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | (bytes[3]);

        playername = Encoding.UTF8.GetString(bytes, 4, nameLen);

        skin = (bytes[4 + nameLen] << 24) | (bytes[5 + nameLen] << 16) | (bytes[6 + nameLen] << 8) | (bytes[7 + nameLen]);
        horn = (bytes[8 + nameLen] << 24) | (bytes[9 + nameLen] << 16) | (bytes[10 + nameLen] << 8) | (bytes[11 + nameLen]);
        playerLevel = bytes[12 + nameLen];
        eloPoints = (bytes[13 + nameLen] << 24) | (bytes[14 + nameLen] << 16) | (bytes[15 + nameLen] << 8) | (bytes[16 + nameLen]);
    }
}
