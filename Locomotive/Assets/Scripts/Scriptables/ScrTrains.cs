using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trains", menuName = "ScriptableObjects/Trains", order = 1)]
public class ScrTrains : ScriptableObject
{
    public TrainPreset[] trains;

    private static ScrTrains inst = null;
    public static ScrTrains Inst
    {
        get
        {
            if (inst == null)
            {
                inst = Resources.Load<ScrTrains>("Trains");
            }

            return inst;
        }
    }
}


[System.Serializable]
public class TrainPreset
{
    public GameObject prefab;
}