using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Componente que controlla el comportamiento del player
/// </summary>
public class PlayerController :  MonoBehaviour {

    //Velocidad del player
    public float speed = 8;

    Transform myTrans;
    Rigidbody2D myRigi;
    float dirX = 0;

    //Variables locales para mantener la posición del player en su inicial
    float posYInitial;
    float posYActual;

    bool buttonRightPressed = false;
    bool buttonLeftPressed = false;

    //Variables que representan los botones de movimiento
    public bool setbuttonRight { set { buttonRightPressed = value; } }
    public bool setbuttonLeft { set { buttonLeftPressed = value; } }

    bool gameOver = false;

	void Start () 
    {
        posYInitial = posYActual = transform.position.y;
        myRigi = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    { 
        #if !UNITY_ANDROID && !UNITY_IPHONE
            Move(Input.GetAxisRaw("Horizontal"));
        #endif

        //Obtenemos la posicion en Y actual
        posYActual = transform.position.y;

        //Si no es igual a la inicial
        if (posYInitial != posYActual)
        {
            //Y si además está fuera de la pantalla y no estamos en gameOver, terminamos el juego
            if (posYActual <= -6.5f && !gameOver)
            {
                //Inidicamos al gameMgr que hemos terminado el juego
                gameOver = true;
                Managers.GetInstance.GameMgr.gameOver();
            }
            //Obtenemos una posicion en Y interpolada a la inicial
            posYActual = Mathf.Lerp(posYActual, posYInitial, 0.1f);
        }

        //Movemos el player a la posición indicada
        Vector2 newPos = new Vector2(transform.position.x + dirX * speed * Time.deltaTime, posYActual);
        myRigi.MovePosition(newPos);
    }

    //Función que sirve para indicar la dirección a la que se mueve el player.
    public void Move(float horizontal_input)
    {
        if(horizontal_input == 0)
        {
            if (buttonRightPressed && !buttonLeftPressed)
            {
                horizontal_input = 1;
            }
            else if (!buttonRightPressed && buttonLeftPressed)
            {
                horizontal_input = -1;
            }
        }

        dirX = horizontal_input;
    }
}
