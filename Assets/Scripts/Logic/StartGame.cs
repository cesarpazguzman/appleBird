using UnityEngine;
using System.Collections;

/// <summary>
/// Componente que se coloca en el gameObject que representa la escena de juego
/// </summary>
public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Managers.GetInstance.SpawnerMgr.clearPool();

        GameController gameMgr = Managers.GetInstance.GameMgr;

        //Inicializamos el gameMgr
        gameMgr.startGame();

        //Ponemos los 3 primeros obstaculos de esta forma
        Managers.GetInstance.SpawnerMgr.createGameObject(gameMgr.getObstacleRandom(), new Vector3(0, 2.5f, 0), Quaternion.identity);
        Managers.GetInstance.SpawnerMgr.createGameObject(gameMgr.getObstacleRandom(), new Vector3(0, 6.8f, 0), Quaternion.identity);
        Managers.GetInstance.SpawnerMgr.createGameObject(gameMgr.getObstacleRandom(), new Vector3(0, 11.1f, 0), Quaternion.identity);

        //Con esto se nos coloca el best Score en la pantalla
        Managers.GetInstance.StorageMgr.setScore(0);
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
