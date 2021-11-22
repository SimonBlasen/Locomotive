using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JobCacheGrid : ThreadedJob
{
    public string filePath;
    public int index;
    public EnvObjectsGrid envObjectsGrid = null;

    protected override void ThreadFunction()
    {
        envObjectsGrid = EnvObjectsGrid.FromBytes(File.ReadAllBytes(filePath));
    }
}
