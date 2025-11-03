using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isVulnerable = true;
    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("Virus") && isVulnerable)
    //    {
    //        Debug.Log("Player hit by Virus");
    //        StartCoroutine(nameof(TakeDamage), 1);
    //    }
    //}

    //private IEnumerator TakeDamage(int damage)
    //{
    //    isVulnerable = false;
    //    GameManager.Instance.LessLife(damage);
    //    yield return new WaitForSeconds(1f);
    //    isVulnerable = true;

    //}


}
