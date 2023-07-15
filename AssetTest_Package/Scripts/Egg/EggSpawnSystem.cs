using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggSpawnSystem 
{
    private float kEggInterval = 0.2f;
    private const float kCoolDownBarSize = 100f;

    // Spawning support
    private GameObject mEggSample = null;
    // handle correct cool off time
    private float mSpawnEggAt = 0f;

    // Count
    private int mEggCount = 0;

    public EggSpawnSystem()
    {
        EggBehavior.InitializeEggSystem(this);

        mEggSample = Resources.Load<GameObject>("Prefabs/Egg") as GameObject;
        mSpawnEggAt = Time.realtimeSinceStartup - kEggInterval; // assume one was shot
    }

    #region Spawning support
    public bool CanSpawn()
    {
        return TimeTillNext() <= 0f;
    }

    public float TimeTillNext()
    {
        float sinceLastEgg = Time.realtimeSinceStartup - mSpawnEggAt;
        return kEggInterval - sinceLastEgg;
    }

    public void SpawnAnEgg(Vector3 p, Vector3 dir)
    {
        Debug.Assert(CanSpawn());
        GameObject e = GameObject.Instantiate(mEggSample) as GameObject;
        e.transform.position = p;
        e.transform.up = dir;
        IncEggCount();
        mSpawnEggAt = Time.realtimeSinceStartup;
    }
    #endregion

    // Count support
    private void IncEggCount() { mEggCount++; }
    public void DecEggCount() { mEggCount--;  }
    public int GetEggCount() { return mEggCount; }
    public string EggSystemStatus() { return "  EGG: OnScreen(" + GetEggCount() + ") ";  }
}
