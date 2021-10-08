using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOffsetManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform playerTransform = null;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private float refreshRate = 5f;
    [SerializeField]
    private int moveThresh = 50;



    private List<GlobalOffsetTransform> globalOffsetTransforms = new List<GlobalOffsetTransform>();
    private List<Transform> quickFireOffsetTransforms= new List<Transform>();
    private float refreshCounter = 0f;

    private Vector3Int globalOffset = Vector3Int.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        refreshCounter += Time.deltaTime;

        if (refreshCounter >= refreshRate)
        {
            refreshCounter = 0f;

            refresh();
        }
    }

    public void RegisterTransform(GlobalOffsetTransform globalOffsetTransform)
    {
        globalOffsetTransforms.Add(globalOffsetTransform);
    }

    public void DeregisterTransform(GlobalOffsetTransform globalOffsetTransform)
    {
        globalOffsetTransforms.Remove(globalOffsetTransform);
    }

    public void RegisterQuickfireTransform(Transform quickFireTransform)
    {
        quickFireOffsetTransforms.Add(quickFireTransform);
    }

    public void DeregisterQuickfireTransform(Transform quickFireTransform)
    {
        quickFireOffsetTransforms.Remove(quickFireTransform);
    }

    private void refresh()
    {
        Vector3Int clampedPlayerPos = new Vector3Int((int)(playerTransform.position.x / moveThresh), (int)(playerTransform.position.y / moveThresh), (int)(playerTransform.position.z / moveThresh));
        clampedPlayerPos *= moveThresh;
        clampedPlayerPos -= globalOffset;

        Vector3Int negativeGlobalOffset = -globalOffset;

        if (negativeGlobalOffset != clampedPlayerPos)
        {
            moveGlobalOffset(-clampedPlayerPos);
        }
    }

    public Vector3Int GlobalOffset
    {
        get
        {
            return globalOffset;
        }
    }

    private void moveGlobalOffset(Vector3Int newGlobalOffset)
    {
        Vector3Int delta = newGlobalOffset - globalOffset;
        globalOffset = newGlobalOffset;

        for (int i = 0; i < globalOffsetTransforms.Count; i++)
        {
            globalOffsetTransforms[i].ApplyGlobalOffset(globalOffset);
        }

        for (int i = 0; i < quickFireOffsetTransforms.Count; i++)
        {
            quickFireOffsetTransforms[i].position += delta;
        }
    }


    private static GlobalOffsetManager inst = null;
    public static GlobalOffsetManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<GlobalOffsetManager>();
            }
            return inst;
        }
    }
}
