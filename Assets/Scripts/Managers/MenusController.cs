using UnityEngine;
using System.Collections;

/// <summary>
/// Componente que gestiona los menús, que no son escenas
/// </summary>
public class MenusController : MonoBehaviour {

    
    public GameObject menuPause;
    public GameObject menuGameOver;
    public GameObject credits;

    Spawner spawner;
    GameObject m_menuPause = null;
    GameObject m_menuGameOver = null;
    GameObject m_currentMenu = null;
    GameObject m_credits = null;

	// Use this for initialization
	void Start () 
    {
        spawner = Managers.GetInstance.SpawnerMgr;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void createMenuPause()
    {
        m_menuPause = spawner.createGameObject(menuPause);
        m_currentMenu = m_menuPause;
    }

    public void createMenuGameOver()
    {
        m_menuGameOver = spawner.createGameObject(menuGameOver);
        m_currentMenu = m_menuGameOver;
    }

    public void createCredits()
    {
        m_credits = spawner.createGameObject(credits);
        m_currentMenu = m_credits;
    }

    public void destroyCurrentMenu()
    {
        spawner.destroyGameObject(m_currentMenu);
    }

}
