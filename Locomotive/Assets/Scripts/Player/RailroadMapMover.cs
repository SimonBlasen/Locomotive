using SappAnims;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailroadMapMover : MonoBehaviour
{
    [SerializeField]
    private SappAnim animMovingMap = null;
    [SerializeField]
    private Transform movingMapBackPos = null;
    [SerializeField]
    private Transform movingMapFrontPos = null;

    // Start is called before the first frame update
    void Start()
    {
        animMovingMap.transform.localPosition = movingMapBackPos.localPosition;
        animMovingMap.transform.localRotation = Quaternion.Euler(movingMapBackPos.localRotation.eulerAngles);
        animMovingMap.LocalPosition = movingMapBackPos.localPosition;
        animMovingMap.LocalRotation = movingMapBackPos.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animMovingMap.LocalPosition = movingMapFrontPos.localPosition;
            animMovingMap.LocalRotation = movingMapFrontPos.localRotation.eulerAngles;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            animMovingMap.LocalPosition = movingMapBackPos.localPosition;
            animMovingMap.LocalRotation = movingMapBackPos.localRotation.eulerAngles;
        }
    }
}
