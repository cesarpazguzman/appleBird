using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// CLase que se coloca en el gameObject que representa la escena. Sirve para cambiar los objetos según la resolución.
/// </summary>
public class changeResolution : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        //1920x1080 es la resolucion con la que estoy trabajando, por lo que cambio apartir de ella.
        float xFactor = Screen.width / 1920f;
        float yFactor = Screen.height / 1080f;


        Camera.main.rect = new Rect(0, 0, 1, xFactor / yFactor);
	}

}
