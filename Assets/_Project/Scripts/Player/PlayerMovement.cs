using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// -RESPONSABILIDAD-
/// Esta clase es la clase base para los diferentes tipos de movimiento del jugador.
/// -POSIBLES UPGRADES-
/// Eliminar el metodo Movement() y que cada clase hija  implemente una interfaz.
/// De este modo, si quiero centralizar todos los componentes de mi objeto "Player" puedo preguntar si alguno de sus componentes aplica
/// una interfaz "IMovement" y llamarle a su metodo Movement().
/// </summary>
public abstract class PlayerMovement : BaseMovement2D
{
    protected Vector2 inputDirection;
    protected bool canMove = true;
    public abstract void OnMove(InputAction.CallbackContext context);
    public abstract void Movement();
    public void OnStop()
    {
        inputDirection = Vector2.zero;
    }


}
