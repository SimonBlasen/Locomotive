using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private float coalBurnStrength = 1f;
    [SerializeField]
    private float coalLifetime = 1f;
    [SerializeField]
    private float maxTemp = 1f;
    //[SerializeField]
    //private float cooldownSpeed = 1f;
    [SerializeField]
    private AnimationCurve coalBurnCurve = null;
    [SerializeField]
    private AnimationCurve cooldownCurve = null;
    [SerializeField]
    private float cooldownStrength = 1f;

    private List<float> coalsBurnedTime = new List<float>();

    private float heat = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        burnCoal();
    }

    private void burnCoal()
    {
        for (int i = 0; i < coalsBurnedTime.Count; i++)
        {
            coalsBurnedTime[i] += Time.deltaTime;

            heat += coalBurnCurve.Evaluate(coalsBurnedTime[i]) * coalBurnStrength * Time.deltaTime;

            if (coalsBurnedTime[i] > coalLifetime)
            {
                coalsBurnedTime.RemoveAt(i);
                i--;
            }
        }

        heat -= cooldownCurve.Evaluate(heat) * Time.deltaTime * cooldownStrength;

        if (heat > maxTemp)
        {
            heat = maxTemp;
        }
        if (heat < 0f)
        {
            heat = 0f;
        }
    }

    public float Heat
    {
        get
        {
            return heat;
        }
    }

    public void AddCoal()
    {
        coalsBurnedTime.Add(0f);
    }
}
