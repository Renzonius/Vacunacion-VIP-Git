using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] private GameObject PositionsContainer;
    public List<Transform> freePositions;
    public List<Transform> lockPositions;

    void Start()
    {
        //SetFreePositions();
    }

    private void SetFreePositions()
    {
        for (int i = 0; i < PositionsContainer.transform.childCount; i++)
        {
            freePositions.Add(PositionsContainer.transform.GetChild(i));
        }
    }


}
