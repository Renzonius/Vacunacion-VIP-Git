using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// -RESPONSABILIDAD-
/// Este script gestiona el comportamiento de un proyectil.
/// -POSIBLES UPGRADES-
/// Eliminar el metodo Awake y asignar la referencia al Rigidbody2D desde el editor.
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IPoolable
{
    private Rigidbody2D rb;
    private ObjectPool<Projectile> pool;
    private float lifetime = 3f;
    private float timer;

    public void SetPool(ObjectPool<Projectile> poolRef)
    {
        pool = poolRef;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnSpawned()
    {
        timer = lifetime;
        rb.velocity = Vector2.zero;
    }

    public void OnDespawned()
    {
        rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            pool.ReturnToPool(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        // Daño, efectos, etc.
        Debug.Log("Projectile triggered: " + tri.gameObject.name);
        pool.ReturnToPool(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    { 
        Debug.Log("Projectile hit: " + col.gameObject.name);
        pool.ReturnToPool(this);
    }
}
