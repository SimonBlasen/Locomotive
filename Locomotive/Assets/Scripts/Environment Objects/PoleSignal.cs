using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PoleSignalState
{
    STOP = 0, SLOW = 1, DRIVE = 2
}

public class PoleSignal : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform armTop = null;
    [SerializeField]
    private Transform armBottom = null;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private AnimationCurve curveMove = null;
    [SerializeField]
    private float moveTime = 1f;
    [SerializeField]
    private float downRotArmTop = 1f;
    [SerializeField]
    private float upRotArmTop = 1f;
    [SerializeField]
    private float downRotArmBottom = 1f;
    [SerializeField]
    private float upRotArmBottom = 1f;

    private float sArmTop = 0f;
    private float sArmBottom = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SignalState = (PoleSignalState)((((int)SignalState) + 1) % 3);
        }

        if (SignalState == PoleSignalState.STOP && sArmTop > 0f)
        {
            sArmTop -= Time.deltaTime / moveTime;
            sArmTop = Mathf.Clamp(sArmTop, 0f, 1f);
            updateArmTop();
        }
        else if ((SignalState == PoleSignalState.DRIVE || SignalState == PoleSignalState.SLOW) && sArmTop < 1f)
        {
            sArmTop += Time.deltaTime / moveTime;
            sArmTop = Mathf.Clamp(sArmTop, 0f, 1f);
            updateArmTop();
        }


        if (SignalState == PoleSignalState.DRIVE && sArmBottom > 0f)
        {
            sArmBottom -= Time.deltaTime / moveTime;
            sArmBottom = Mathf.Clamp(sArmBottom, 0f, 1f);
            updateArmBottom();
        }
        else if ((SignalState == PoleSignalState.STOP || SignalState == PoleSignalState.SLOW) && sArmBottom < 1f)
        {
            sArmBottom += Time.deltaTime / moveTime;
            sArmBottom = Mathf.Clamp(sArmBottom, 0f, 1f);
            updateArmBottom();
        }
    }

    private void updateArmTop()
    {
        float rotZ = Mathf.Lerp(downRotArmTop, upRotArmTop, curveMove.Evaluate(sArmTop));
        armTop.localRotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    private void updateArmBottom()
    {
        float rotZ = Mathf.Lerp(downRotArmBottom, upRotArmBottom, curveMove.Evaluate(sArmBottom));
        armBottom.localRotation = Quaternion.Euler(0f, 0f, rotZ);
    }


    private PoleSignalState curState = PoleSignalState.DRIVE;
    public PoleSignalState SignalState
    {
        get
        {
            return curState;
        }
        set
        {
            curState = value;
        }
    }
}
