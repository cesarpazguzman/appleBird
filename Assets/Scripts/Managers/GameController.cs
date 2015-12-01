using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Componente que gestiona el juego
/// </summary>
public class GameController : MonoBehaviour {

    [SerializeField]
    public List<GameObject> Obstacles;//Lista de todos los obstáculos disponibles
    public float separationObstacles;
    
    Text m_textScore;
    public Text textScore { set { m_textScore = value; } }

    int m_score;

    GameObject currentObstacle;

    List<GameObject> ObstaclesAux = new List<GameObject>();

    //Para gestionar las velocidades de los obstaculos
    public float speedObstacles = -2f;
    public float maxSpeedObstacles;

    private static GameController m_instance = null;

    //Audios de efectos
    public AudioClip audioEatApple;
    public AudioClip audioDeath;

    int dificulty;

    void Awake()
    {
        //Para no destruir el Manager entre escenas
        if (m_instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            m_instance = this;
        }
    }

	void Start () 
    {
        startGame();
	}

    void initializeObstacles()
    {
        ObstaclesAux.Clear();
        foreach (GameObject goObstacle in Obstacles.GetRange(0, dificulty))
        {
            ObstaclesAux.Add(goObstacle);
        }
    }

    //Cuando pasen 30 segundos, aumentamos los obstáculos, para que aparezcan más
    IEnumerator setDificulty()
    {
        yield return new WaitForSeconds(30f);
        dificulty = Obstacles.Count;
        
    }

	// Update is called once per frame
	void Update () 
    {
	
	}

    //Funcion que obtiene un obstáculo aleatorio
    public GameObject getObstacleRandom()
    {
        if (ObstaclesAux.Count == 0)
            initializeObstacles();

        currentObstacle = ObstaclesAux[Random.Range(0, ObstaclesAux.Count)];
        ObstaclesAux.Remove(currentObstacle);

        return currentObstacle;
    }

    //Corutina para ir aumentando la velocidad del escenario
    IEnumerator updateSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            if (speedObstacles >= maxSpeedObstacles)
                speedObstacles -= 0.1f;
        }
    }

    public void eatApple()
    {
        //Al comer una manzana aumentamos puntuación
        ++m_score;
        
        if(m_textScore != null)
            m_textScore.text = "SCORE: " + m_score.ToString();

        //Sonido de manzanas
        this.gameObject.GetComponent<AudioSource>().clip = audioEatApple;
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    //Función que gestiona el termino del juego
    public void gameOver()
    {
        //Sonido de muerte
        this.gameObject.GetComponent<AudioSource>().clip = audioDeath;
        this.gameObject.GetComponent<AudioSource>().Play();

        //Paramos el juego y creamos el menu del gameOver, y miramos si esta es la mejor puntuación
        Time.timeScale = 0;
        Managers.GetInstance.MenuMgr.createMenuGameOver();
        Managers.GetInstance.StorageMgr.setScore(m_score);

        //Paramos las coroutinas
        StopCoroutine(updateSpeed());
        StopCoroutine(setDificulty());
    }

    //Función para inicializar el juego
    public void startGame()
    {
        initializeObstacles();

        m_score = 0;

        speedObstacles = -2f;

        dificulty = 3;

        StartCoroutine(updateSpeed());

        StartCoroutine(setDificulty());
    }
}
