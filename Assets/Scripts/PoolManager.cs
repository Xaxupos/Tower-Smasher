using System.Collections;
using UnityEngine;
using VInspector;

public class PoolManager : MonoBehaviourSingleton<PoolManager>
{
    public SerializedDictionary<PooledType, Pool> objectPools = new();

    protected override void Awake()
    {
        base.Awake();

        foreach (var pool in objectPools)
        {
            pool.Value.InitPool(() =>
                {
                    var obj = Instantiate(pool.Value.ObjectPrefab, gameObject.transform);
                    return obj;
                },
                obj => { obj.SetActive(true); },
                obj => { obj.SetActive(false); },
                obj => { Destroy(obj); },
                0, 15);
        }
    }
    
    public GameObject GetFromPool(PooledType objectType)
    {
        if (objectPools.TryGetValue(objectType, out Pool returnedPool))
        {
            return returnedPool.ObjectPool.Get();
        }

        Debug.LogError($"Cannot get an object of type {objectType} from the Pool! Returned null!");
        return null;
    }

    public void ReleaseToPool(PooledType objectType, GameObject objectToRelease, float delay = 0.0f)
    {
        if (objectPools.TryGetValue(objectType, out Pool returnedPool))
        {
            if (delay <= 0)
                returnedPool.ObjectPool.Release(objectToRelease);
            else
                StartCoroutine(DelayedRelease(delay, returnedPool, objectToRelease));

            return;
        }

        Debug.LogError($"Cannot release an {objectToRelease.name} of type {objectType} back to the Pool!");
    }
    
    private IEnumerator DelayedRelease(float delay, Pool poolToReturn, GameObject objToRelease)
    {
        yield return new WaitForSeconds(delay);

        if (poolToReturn == null || objToRelease == null) yield break;

        poolToReturn.ObjectPool.Release(objToRelease);
    }
}