using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailroadMapTrainPose : MonoBehaviour
{
    [SerializeField]
    private Transform leftBottomPos = null;
    [SerializeField]
    private Transform rightTopPos;
    [SerializeField]
    private Transform worldLeftBottomPos = null;
    [SerializeField]
    private Transform worldRightTopPos;
    [SerializeField]
    private float yRotOffset = 0f;


    private Train train;

    // Start is called before the first frame update
    void Start()
    {
        train = GetComponentInParent<Train>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 interpols = new Vector2(Mathf.InverseLerp(worldLeftBottomPos.position.x, worldRightTopPos.position.x, train.Locomotive.transform.position.x),
                            Mathf.InverseLerp(worldLeftBottomPos.position.z, worldRightTopPos.position.z, train.Locomotive.transform.position.z));

        transform.localPosition = new Vector3(Mathf.Lerp(leftBottomPos.localPosition.x, rightTopPos.localPosition.x, interpols.x),
                                        Mathf.Lerp(leftBottomPos.localPosition.y, rightTopPos.localPosition.y, interpols.y), 
                                        0f);

        float trainAngle = train.Locomotive.transform.rotation.eulerAngles.y;
        transform.localRotation = Quaternion.Euler(0f, 0f, -trainAngle + yRotOffset);
    }
}
