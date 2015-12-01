using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

/// <summary>
/// Manager que guarda la mejor puntuación. Almacenamiento persistente y volatil
/// </summary>
public class StorageManager : MonoBehaviour {

    //Almacenamiento volátil
    private int m_bestScore;
    public int bestScore { get { return m_bestScore; } }

    Text m_textBestScore;
    public Text textBestScore { set { m_textBestScore = value; } }

    void Awake()
    {
        readFile();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Funcion que lee fichero json
    private void readFile()
    {
        //Si es la primera vez que se juega, entonces el fichero no existira, por lo que lo comprobamos
        if (System.IO.File.Exists(Application.persistentDataPath + "/bestScore.txt"))
        {
            //Obtenemos la primera linea, que solo será la puntuación mejor
            string[] lines = File.ReadAllLines(Application.persistentDataPath + "/bestScore.txt");

            m_bestScore = Convert.ToInt32(lines[0]);
        }
        else
        {
            m_bestScore = 0;
        }

    }

    public void setScore(int score)
    {
        //Almacenamos la mejor puntuacion
        if (m_bestScore < score)
        { 
            m_bestScore = score;  
        }
        m_textBestScore.text = m_bestScore.ToString();
    }

    public void writeFile()
    {
        //Escribimos en un fichero la mejor puntuación
        File.WriteAllText(Application.persistentDataPath + "/bestScore.txt", m_bestScore.ToString());
    }
}
