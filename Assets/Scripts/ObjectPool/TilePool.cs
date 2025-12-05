using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using VContainer;

public class TilePool
{
    private const int INITIAL_SIZE = 50;
     public GameObject prefab;
    private Dictionary<Type, Queue<IGridPlaceable>> pools = new Dictionary<Type, Queue<IGridPlaceable>>();

    [Inject]
    public TilePool(PoolPrefab)
    {
        
        CreatePool();
    }

    private void CreatePool()
    {
        foreach (var tp in poolPrefabs)
        {
            var component = tp.prefab.GetComponent<IGridPlaceable>();
            if (component == null)
            {
                Debug.LogError($"{tp.prefab.name} does not implement IGridPlaceable!");
                continue;
            }

            var type = component.GetType();
            if (!pools.ContainsKey(type))
                pools[type] = new Queue<IGridPlaceable>();

            for (int i = 0; i < tp.initialSize; i++)
            {
                var obj = UnityEngine.Object.Instantiate(tp.prefab, transform).GetComponent<IGridPlaceable>();
                objAsGameObject(obj).SetActive(false);
                pools[type].Enqueue(obj);
            }
        }
    }
    public T Get<T>() where T : class, IGridPlaceable
    {
        var type = typeof(T);
        if (!pools.ContainsKey(type))
        {
            Debug.LogError($"No pool for type {type}");
            return null;
        }

        var pool = pools[type];
        if (pool.Count == 0)
        {
            Debug.Log($"Pool empty for {type}, creating new one.");
            var prefab = Array.Find(poolPrefabs, x => x.prefab.GetComponent<T>() != null).prefab;
            var obj = Instantiate(prefab, transform).GetComponent<T>();
            objAsGameObject(obj).SetActive(false);
            pool.Enqueue(obj);
        }

        var tile = pool.Dequeue();
        objAsGameObject(tile).SetActive(true);
        (tile as IPoolable)?.OnSpawn();
        return tile as T;
    }

    public void Return(IGridPlaceable tile)
    {
        (tile as IPoolable)?.OnDespawn();
        objAsGameObject(tile).SetActive(false);
        tileAsTransform(tile).SetParent(transform);

        var type = tile.GetType();
        if (!pools.ContainsKey(type))
            pools[type] = new Queue<IGridPlaceable>();

        pools[type].Enqueue(tile);
    }

    private GameObject objAsGameObject(IGridPlaceable obj) => (obj as MonoBehaviour).gameObject;
    private Transform tileAsTransform(IGridPlaceable obj) => (obj as MonoBehaviour).transform;
}

public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}

