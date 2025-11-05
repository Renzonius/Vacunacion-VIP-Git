using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isVulnerable = true;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject?.GetComponent<NPCHealth>())
        {
            NPCHealth npcHealth = col.gameObject.GetComponent<NPCHealth>();
            if (npcHealth.isSick && isVulnerable)
            {
                StartCoroutine(TakeDamage(1));
                CameraShake.Instance.Shake(2f, 2f, 0.2f);
            }
        }

    }

    private IEnumerator TakeDamage(int damage)
    {
        isVulnerable = false;
        GameManager.Instance.LessLife(damage);
        yield return new WaitForSeconds(1f);
        isVulnerable = true;

    }


}
