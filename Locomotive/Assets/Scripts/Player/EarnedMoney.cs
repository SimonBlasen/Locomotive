using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarnedMoney : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshMoney = null;

    // Start is called before the first frame update
    void Start()
    {
        refreshTextmesh();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            money = value;

            refreshTextmesh();
        }
    }


    private void refreshTextmesh()
    {
        textMeshMoney.text = money.ToString("n2") + " €";
    }
}
