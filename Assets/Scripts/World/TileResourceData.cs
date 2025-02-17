﻿using System;
using UnityEngine;

[Serializable]
public class TileResourceData
{
    [SerializeField] private bool spawnResource;
    [SerializeField] private bool hasResource;
    [SerializeField] private long spawnMinute;

    public bool SpawnResource
    {
        get => spawnResource;
        set => spawnResource = value;
    }

    public bool HasResource
    {
        get => hasResource;
        set => hasResource = value;
    }

    public long SpawnMinute
    {
        get => spawnMinute;
        set => spawnMinute = value;
    }
    
    
}