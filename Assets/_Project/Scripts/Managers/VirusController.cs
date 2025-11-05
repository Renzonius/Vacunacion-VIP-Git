using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    [SerializeField] private float timeToActivate;
    [SerializeField] private float contagionSpeed;
    [SerializeField] private List<NPCController> npcControllers;

    private void Start()
    {
        StartCoroutine(SicknessCoroutine());
    }


    private IEnumerator SicknessCoroutine()
    {
        yield return new WaitForSeconds(timeToActivate);
        foreach (var npc in npcControllers)
        {
            npc.MakeSick();
            GameManager.Instance.AddVirus(1);
            yield return new WaitForSeconds(contagionSpeed);
        }
    }
}
