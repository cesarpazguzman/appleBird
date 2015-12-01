using UnityEngine;
using System.Collections;

/// <summary>
/// Componente que se coloca en las nubes para que vayen bajando a una velocidad 
/// </summary>
public class ItemsController : MonoBehaviour {

    public float speed = 5f;
    public float displacement;

    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Vamos moviendo la nube hacia abajo
        transform.position += Vector3.up * Managers.GetInstance.GameMgr.speedObstacles * Time.deltaTime;
	}

    void OnBecameInvisible()
    {
        //Cuando la nube ya no es visible por la cámara, la volvemos a subir 
        transform.position += Vector3.up*displacement;
    }
}
