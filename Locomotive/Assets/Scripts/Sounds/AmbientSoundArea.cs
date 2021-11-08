using Sappph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundArea : MonoBehaviour
{
    [SerializeField]
    private AmbientEnvironmentType areaType = AmbientEnvironmentType.FIELD;


    [SerializeField]
    private SpawnedSound[] spawnedSounds = null;

    [Space]

    [Header("Prefabs")]
    [SerializeField]
    private GameObject prefabAmbientToSpawnSound = null;

    private AmbientSampleSpawner ambientSampleSpawner = null;

    // Start is called before the first frame update
    void Start()
    {
        ambientSampleSpawner = GetComponentInParent<AmbientSampleSpawner>();

        for (int i = 0; i < spawnedSounds.Length; i++)
        {
            spawnedSounds[i].timeTillSpawn = Utils.NormalDistribution(spawnedSounds[i].averageTimeBetween, spawnedSounds[i].timeBetweenVariance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ambientSampleSpawner.CurrentAreaType == areaType)
        {
            for (int i = 0; i < spawnedSounds.Length; i++)
            {
                spawnedSounds[i].timeTillSpawn -= Time.deltaTime;

                if (spawnedSounds[i].timeTillSpawn <= 0f)
                {
                    spawnedSounds[i].timeTillSpawn = Utils.NormalDistribution(spawnedSounds[i].averageTimeBetween, spawnedSounds[i].timeBetweenVariance);

                    spawnSound(spawnedSounds[i]);
                }
            }
        }
    }

    private void spawnSound(SpawnedSound sound)
    {
        GameObject instSoundGo = Instantiate(prefabAmbientToSpawnSound, transform);
        float radius = Mathf.Lerp(sound.minDistance, sound.maxDistance, UnityEngine.Random.Range(0f, 1f));

        float randAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);
        Vector2 dirVec = new Vector2(Mathf.Sin(randAngle), Mathf.Cos(randAngle));
        RaycastHit hit;
        if (Physics.Raycast(new Ray(ambientSampleSpawner.Train.Locomotive.transform.position + (new Vector3(dirVec.x, 0f, dirVec.y)) * radius + Vector3.up * 400f, Vector3.down), out hit, 1000f))
        {
            instSoundGo.transform.position = hit.point;
        }

        AmbientSoundToSpawn ambientSoundToSpawn = instSoundGo.GetComponent<AmbientSoundToSpawn>();
        ambientSoundToSpawn.FmodEventID = sound.fmodEventAmbientSound;
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < spawnedSounds.Length; i++)
        {
            if (spawnedSounds[i].preview)
            {
                Vector3 midPos = FindObjectOfType<Locomotive>().transform.position;

                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(midPos, spawnedSounds[i].minDistance);
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(midPos, spawnedSounds[i].maxDistance);

                //Gizmos.DrawSphere(ambientBorders[i].railSegment.Spline.GetSampleAtDistance(Mathf.Clamp(ambientBorders[i].pos + 1f, 0f, ambientBorders[i].railSegment.Spline.Length)).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);
            }


        }
    }
}


[Serializable]
public class SpawnedSound
{
    public bool preview = false;

    [FMODUnity.EventRef]
    public string fmodEventAmbientSound;

    public float minDistance = 2f;
    public float maxDistance = 12f;

    public float averageTimeBetween = 20f;
    public float timeBetweenVariance = 4f;

    [HideInInspector]
    public float timeTillSpawn = 0f;
}
