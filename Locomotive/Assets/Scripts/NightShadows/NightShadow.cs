using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadow : MonoBehaviour
{
    [SerializeField]
    private float raycastTime = 0.5f;
    [SerializeField]
    private float lerpSpeed = 0.5f;
    [SerializeField]
    private float maxSideAngle = 100f;
    [SerializeField]
    private float dieOffsetSpeed = 30f;
    [SerializeField]
    private float dieDistance = 200f;
    [SerializeField]
    private float distanceToLoc = 0f;
    [SerializeField]
    private float distanceToLocMoveSpeed = 4f;


    private float targetTrainDistance = 0f;

    private float multipleOfDistanceSpawn = 4f;

    private float raycastCounter = 0f;
    private float yRaycast = 0f;

    private float sideAngle = 0f;

    private Vector3 targetPos = Vector3.zero;

    private float dyingOffset = 0f;
    private bool isDying = false;


    // Start is called before the first frame update
    void Start()
    {
        float randAngle = Random.Range(0f, 360f);

        transform.position = Train.Locomotive.transform.position + (Quaternion.Euler(0f, randAngle, 0f) * Vector3.forward) * NightShadowsManager.DistanceToLoc * multipleOfDistanceSpawn;

        sideAngle = Random.Range(-maxSideAngle, maxSideAngle);
    }

    // Update is called once per frame
    void Update()
    {
        raycastCounter += Time.deltaTime;
        if (raycastCounter >= raycastTime)
        {
            raycastCounter = 0f - Random.Range(0f, 0.1f);

            raycastGround();
        }

        targetPos = Train.Locomotive.transform.position + (Quaternion.Euler(0f, sideAngle, 0f) * (Train.Locomotive.transform.forward * -1f)) * (distanceToLoc + dyingOffset);
        targetPos.y = yRaycast;
        Vector3 oldPos = transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        transform.forward = transform.position - oldPos;

        if (isDying)
        {
            dyingOffset += dieOffsetSpeed * Time.deltaTime;

            if (dyingOffset >= dieDistance)
            {
                Debug.Log("Night shadow destroyed");
                Destroy(gameObject);
            }
        }


        distanceToLoc = Mathf.MoveTowards(distanceToLoc, targetTrainDistance, Time.deltaTime * distanceToLocMoveSpeed);
        if (Mathf.Abs(distanceToLoc - targetTrainDistance) <= 0.1f)
        {
            targetTrainDistance = Random.Range(0f, 200f);
        }
    }

    private void raycastGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(new Vector3(transform.position.x, 6500f, transform.position.z), Vector3.down), out hit, 7000f, LayerMask.GetMask("Terrain")))
        {
            yRaycast = hit.point.y;
        }
    }

    public NightShadowsManager NightShadowsManager
    {
        get; set;
    } = null;

    public Train Train
    {
        get; set;
    } = null;

    public void KillShadow()
    {
        isDying = true;
    }
}
