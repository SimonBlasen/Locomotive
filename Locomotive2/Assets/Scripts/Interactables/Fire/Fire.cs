using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

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

    private StudioEventEmitter stevem = null;

    // Start is called before the first frame update
    void Start()
    {
        stevem = GetComponent<StudioEventEmitter>();
        stevem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        burnCoal();

        stevem.SetParameter("FireValue", Mathf.Clamp((heat / 350f) * 3f, 0f, 1f));
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
