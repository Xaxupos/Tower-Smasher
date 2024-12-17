using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;
using System;

[System.Serializable]
public class Pool
{
    public ObjectPool<GameObject> ObjectPool { get; set; }
    public GameObject ObjectPrefab;
    
    private int _lastIndex;
    
    public void InitPool(Func<GameObject> createAction, Action<GameObject> onGetAction,
        Action<GameObject> onReleaseAction, Action<GameObject> onDestroyAction, int defaultSize, int maxSize)
    {
        ObjectPool = new ObjectPool<GameObject>(createAction, onGetAction, onReleaseAction, onDestroyAction, true, defaultSize, maxSize);
    }
}