using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAudioTest : MonoBehaviour
{
    public ProcAudioGraph procAudioGraph = null;

    private double oldDSP = 0f;
    private double runningTime = 0f;

    private double timePerTick = 0f;

    public double bpm = 140.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;

    private double nextTick = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int accent;
    private bool running = false;

    private int samplesCount = 0;

    private int oldTime = 0;

    void Start()
    {
        accent = signatureHi;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick * sampleRate;
        running = true;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        double timeDiff = (AudioSettings.dspTime - oldDSP);
        if (true || timePerTick == 0f)
        {
            timePerTick = timeDiff;
        }

        if (runningTime >= 60.0)
        {
            runningTime = 0.0;
        }

        oldDSP = AudioSettings.dspTime;

        //Debug.Log(AudioSettings.dspTime);

        double[] times = new double[data.Length];
        for (int d = 0; d < data.Length; d++)
        {
            runningTime += timePerTick / (data.Length);
            times[d] = runningTime;
        }

        float[] vals = new float[0];
        for (int i = 0; i < procAudioGraph.nodes.Count; i++)
        {
            if (typeof(PAParentTimedependend).IsAssignableFrom(procAudioGraph.nodes[i].GetType()))
            {
                PAParentTimedependend pANodeTimedependend = (PAParentTimedependend)procAudioGraph.nodes[i];

                pANodeTimedependend.times = times;
            }
            if (typeof(PAParentGenerator).IsAssignableFrom(procAudioGraph.nodes[i].GetType()))
            {
                PAParentGenerator pANodeGenerator = (PAParentGenerator)procAudioGraph.nodes[i];

                pANodeGenerator.sampleSize = data.Length;
            }
        }


        for (int i = 0; i < procAudioGraph.nodes.Count; i++)
        {
            if (procAudioGraph.nodes[i].GetType() == typeof(PANodeOutput))
            {
                vals = (float[])procAudioGraph.nodes[i].GetValue(procAudioGraph.nodes[i].GetOutputPort("audioOutput"));
                break;
            }
        }

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = vals[i];
        }


        samplesCount += data.Length;



        int newTime = (int)AudioSettings.dspTime;

        if (newTime != oldTime)
        {
            //Debug.Log(samplesCount.ToString());


            samplesCount = 0;
        }

        oldTime = (int)AudioSettings.dspTime;




        /*
        if (!running)
            return;

        double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        double sample = AudioSettings.dspTime * sampleRate;
        int dataLen = data.Length / channels;

        int n = 0;
        while (n < dataLen)
        {
            float x = gain * amp * Mathf.Sin(phase);
            int i = 0;
            while (i < channels)
            {
                data[n * channels + i] += x;
                i++;
            }
            while (sample + n >= nextTick)
            {
                nextTick += samplesPerTick;
                amp = 1.0F;
                if (++accent > signatureHi)
                {
                    accent = 1;
                    amp *= 2.0F;
                }
                Debug.Log("Tick: " + accent + "/" + signatureHi);
            }
            phase += amp * 0.3F;
            amp *= 0.993F;
            n++;
        }*/
    }
}
