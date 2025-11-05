using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateToCursor : MonoBehaviour
{
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle += 3f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
