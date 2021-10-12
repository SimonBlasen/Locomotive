using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundToSpawn : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter emitter = null;

    // Start is called before the first frame update
    void Start()
    {
        emitter.Event = FmodEventID;
        emitter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (emitter.IsPlaying() == false)
        {
            Destroy(gameObject);
        }
    }

    public string FmodEventID
    {
        get; set;
    } = "";
}
