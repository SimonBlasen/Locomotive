using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField]
    private Fire fire = null;
    [SerializeField]
    private float tempLerpSpeed = 0.1f;
    [SerializeField]
    private float pressureIncreaseSpeed = 1f;
    [SerializeField]
    private AnimationCurve generatedPressure = null;
    [SerializeField]
    private float generalPressureDecrease = 1f;
    [SerializeField]
    private float maxPressure = 400f;
    [SerializeField]
    private float releaseValveStrength = 400f;

    private float curTemp = 0f;

    private float pressure = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heat();
        generatePressure();

        if (ReleaseSteam)
        {
            releaseSteam();
        }



        if (pressure < 0f)
        {
            pressure = 0f;
        }
        else if (pressure > maxPressure)
        {
            pressure = maxPressure;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            pressure = maxPressure * 0.75f;
        }
    }

    private void releaseSteam()
    {
        pressure -= Time.deltaTime * releaseValveStrength;
    }

    private void heat()
    {
        curTemp = Mathf.Lerp(curTemp, fire.Heat, Time.deltaTime * tempLerpSpeed);
    }

    private void generatePressure()
    {
        pressure += generatedPressure.Evaluate(curTemp) * Time.deltaTime * pressureIncreaseSpeed;

        pressure -= Time.deltaTime * generalPressureDecrease;
    }

    public float Pressure
    {
        get
        {
            return pressure;
        }
    }

    public float UseUpPressure(float amount)
    {
        if (pressure > amount)
        {
            pressure -= amount;

            return amount;
        }
        else
        {
            float used = pressure;
            pressure = 0f;

            return used;
        }
    }

    public bool ReleaseSteam
    {
        get; set;
    } = false;
}
