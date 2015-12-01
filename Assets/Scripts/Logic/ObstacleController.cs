using UnityEngine;
using System.Collections;


/// <summary>
/// Componente que se coloca en los obstaculos.
/// </summary>
public class ObstacleController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Movemos el obstaculo hacia abajo
        transform.position += Vector3.up * Managers.GetInstance.GameMgr.speedObstacles * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        //Comprobacion a prueba de errores, dado que esta funcion también es llamada cuando salimos de la escena de juego
        if(this.gameObject.activeInHierarchy)
            StartCoroutine(createGameObject()); 
    }

    IEnumerator createGameObject()
    {
        //Esperamos al final del frame
        yield return new WaitForEndOfFrame();

        //Destruimos este obstaculo
        Managers.GetInstance.SpawnerMgr.destroyGameObject(this.gameObject);

        //Obtenemos una posicion nueva para poner el nuevo obstaculo
        transform.position += Vector3.up * Managers.GetInstance.GameMgr.separationObstacles;

        //Creamos un nuevo obstaculo en la posicion indicada
        GameObject go = Managers.GetInstance.SpawnerMgr.createGameObject(Managers.GetInstance.GameMgr.getObstacleRandom(),
            transform.position, transform.rotation);

        //Activamos las manzanas
        foreach (Transform go2 in go.transform)
        {
            go2.gameObject.SetActive(true);
        }
    }
}
