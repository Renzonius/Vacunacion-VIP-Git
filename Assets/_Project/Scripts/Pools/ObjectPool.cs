using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// -RESPONSABILIDAD-
/// Este script implementa un sistema de pooling genérico para optimizar la reutilización de objetos en Unity.
/// -COMENTARIOS-
/// public class ObjectPool<T> where T : Component, IPoolable
/// Estalinea define una clase genérica ObjectPool que puede manejar cualquier tipo de componente T que implemente la interfaz IPoolable.
/// Desta manera, el sistema de pooling puede ser utilizado con diferentes tipos de objetos (por ejemplo, proyectiles, enemigos, efectos visuales) 
/// siempre que implementen los métodos OnSpawned y OnDespawned definidos en la interfaz IPoolable.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : Component, IPoolable
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Transform parent;

    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            ExpandPool();
        }

        T obj = pool.Dequeue();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.gameObject.SetActive(true);
        obj.OnSpawned();
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.OnDespawned();
        pool.Enqueue(obj);
    }

    private void ExpandPool()
    {
        T obj = GameObject.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
