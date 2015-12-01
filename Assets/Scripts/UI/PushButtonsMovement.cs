using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Componente que va en los botones de movimiento
/// </summary>
public class PushButtonsMovement : MonoBehaviour {

    [Range(-1, 1)]
    public int moveDir = 1;
    PlayerController playerController;

	void Start () 
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

	}

    public void pointerDown()
    {
        //Si estamos pulsando uno de los botones le indicamos al player la dirección
        indicatePlayerButtonPressed(true);
        playerController.Move(moveDir);
    }

    public void pointerUp()
    {
        //Si dejamos de pulsar le indicamos que hemos de dejar de pulsarlo
        indicatePlayerButtonPressed(false);
        playerController.Move(0);
    }

    void indicatePlayerButtonPressed(bool activate)
    {
        switch (moveDir)
        {
            //De esta manera lo que hacemos es que si pulsamos dos botones a la vez, al soltar uno, se quede el movimiento del otro.
            case -1:
                playerController.setbuttonLeft = activate;
                break;
            case 1:
                playerController.setbuttonRight = activate;
                break;
        }
    }

    
}
