using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Position : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject npcInPosition;


    public void ClearPosition()
    {
        isOccupied = false;
        npcInPosition = null;
    }

    public void SetPosition(GameObject npc)
    {
        isOccupied = true;
        npcInPosition = npc;
    }
}
