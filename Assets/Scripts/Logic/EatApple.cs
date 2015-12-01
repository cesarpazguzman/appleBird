using UnityEngine;
using System.Collections;

/// <summary>
/// Componente que actúa cuando el player se come una manzana
/// </summary>
public class EatApple : MonoBehaviour {

    //Particulas que aparecen al comerse la manzana. 
    public GameObject particlesApple;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Activamos las particulas. 
        particlesApple.SetActive(true);

        //Desactivamos la manzana
        this.gameObject.SetActive(false); 
 
        //Le indicamos al gameMgr que hemos comido una manzana
        Managers.GetInstance.GameMgr.eatApple();
    }
}
