using UnityEngine;
using System.Collections;

public class Managers
{
    private static Managers m_instance = null;
    private GameObject m_managers = null;

    //Managers. Estaticos para que sean más fácilmente accesibles
    private Spawner m_SpawnerMgr = null;
    public Spawner SpawnerMgr { get { return m_SpawnerMgr; } }
    private GameController m_GameMgr = null;
    public GameController GameMgr { get { return m_GameMgr; } }
    private MenusController m_MenuMgr = null;
    public MenusController MenuMgr { get { return m_MenuMgr; } }
    private StorageManager m_StorageMgr = null;
    public StorageManager StorageMgr { get { return m_StorageMgr; } }

    //Constructor
    private Managers()
    {
        if (m_managers == null)
        {
            m_managers = GameObject.Instantiate(Resources.Load("Prefabs/Manager") as GameObject);

            if (m_managers != null)
            {
                m_SpawnerMgr = m_managers.GetComponent<Spawner>();
                m_GameMgr = m_managers.GetComponent<GameController>();
                m_MenuMgr = m_managers.GetComponent<MenusController>();
                m_StorageMgr = m_managers.GetComponent<StorageManager>();
            }
        }
    }

    //Property of m_instance
    public static Managers GetInstance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new Managers();
            }
            return m_instance;
        }
    }
}
