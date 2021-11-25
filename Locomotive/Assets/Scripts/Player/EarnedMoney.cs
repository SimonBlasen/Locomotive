using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarnedMoney : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshMoney = null;
    [SerializeField]
    private float timeForMoneyGoUp = 3f;
    [SerializeField]
    private StudioEventEmitter moneyUpSound = null;

    private float moneyNotChangedFor = 0f;
    private float moneyFrom = 0f;

    private bool updatingMoneyText = false;
    private float updateMoneyTextS = 0f;

    // Start is called before the first frame update
    void Start()
    {
        refreshTextmesh(money);

        moneyFrom = money;
    }

    // Update is called once per frame
    void Update()
    {
        moneyNotChangedFor += Time.deltaTime;

        if (moneyNotChangedFor >= 2f && moneyFrom != money && updatingMoneyText == false)
        {
            //moneyFrom = money;
            updateMoneyDisplay();
        }

        if (updatingMoneyText)
        {
            updateMoneyTextS += Time.deltaTime / timeForMoneyGoUp;
            updateMoneyTextS = Mathf.Clamp(updateMoneyTextS, 0f, 1f);

            float moneyDisplay = Mathf.Lerp(moneyFrom, money, updateMoneyTextS);
            refreshTextmesh(moneyDisplay);

            if (updateMoneyTextS >= 1f)
            {
                updatingMoneyText = false;
                moneyFrom = money;
            }
        }
    }


    private void updateMoneyDisplay()
    {
        updatingMoneyText = true;
        updateMoneyTextS = 0f;

        if (money > moneyFrom)
        {
            moneyUpSound.Play();
        }
    }

    private float money = 0f;
    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            float oldVal = money;
            money = value;

            if (oldVal != money)
            {
                moneyNotChangedFor = 0f;
            }
        }
    }


    private void refreshTextmesh(float displayedMoney)
    {
        textMeshMoney.text = displayedMoney.ToString("n2") + " €";
    }
}
