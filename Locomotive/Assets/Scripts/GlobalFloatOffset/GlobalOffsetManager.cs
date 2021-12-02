using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOffsetManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform playerTransform = null;
    [SerializeField]
    private float snapDistance = 0f;
    [SerializeField]
    private Transform[] snapTransforms = null;

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
        Vector3 overridePlayerPos = playerTransform.position;
        for (int i = 0; i < snapTransforms.Length; i++)
        {
            float distance = Vector2.Distance(new Vector2(snapTransforms[i].position.x, snapTransforms[i].position.z), new Vector2(playerTransform.position.x, playerTransform.position.z));

            if (distance <= snapDistance)
            {
                overridePlayerPos = snapTransforms[i].position;
            }
        }

        Vector3 pos = new Vector3(overridePlayerPos.x + moveThresh * 0.5f, overridePlayerPos.y + moveThresh * 0.5f, overridePlayerPos.z + moveThresh * 0.5f);
        Vector3Int clampedPlayerPos = new Vector3Int((int)(pos.x / moveThresh), (int)(pos.y / moveThresh), (int)(pos.z / moveThresh));
        if (pos.x < 0f)
        {
            clampedPlayerPos.x = (int)((pos.x / moveThresh) - 1f);
        }
        if (pos.y < 0f)
        {
            clampedPlayerPos.y = (int)((pos.y / moveThresh) - 1f);
        }
        if (pos.z < 0f)
        {
            clampedPlayerPos.z = (int)((pos.z / moveThresh) - 1f);
        }


        clampedPlayerPos *= moveThresh;
        clampedPlayerPos -= globalOffset;

        //Debug.Log("player pos: " + (playerTransform.position - globalOffset).ToString());

        Vector3Int negativeGlobalOffset = -globalOffset;

        if (negativeGlobalOffset != clampedPlayerPos)
        {
            moveGlobalOffset(-clampedPlayerPos);
        }
    }

    public Vector3Int GetPotentialGlobalOffset(Vector3 pos)
    {
        pos += new Vector3(moveThresh * 0.5f, moveThresh * 0.5f, moveThresh * 0.5f);
        Vector3Int clampedPlayerPos = new Vector3Int((int)(pos.x / moveThresh), (int)(pos.y / moveThresh), (int)(pos.z / moveThresh));
        if (pos.x < 0f)
        {
            clampedPlayerPos.x = (int)((pos.x / moveThresh) - 1f);
        }
        if (pos.y < 0f)
        {
            clampedPlayerPos.y = (int)((pos.y / moveThresh) - 1f);
        }
        if (pos.z < 0f)
        {
            clampedPlayerPos.z = (int)((pos.z / moveThresh) - 1f);
        }
        clampedPlayerPos *= moveThresh;
        return clampedPlayerPos;
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
