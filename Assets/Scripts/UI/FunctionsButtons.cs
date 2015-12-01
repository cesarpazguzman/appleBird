using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Componente qe representa las funciones al pulsar un botón
/// </summary>
public class FunctionsButtons : MonoBehaviour {

    MenusController MenuMgr;

    void Start()
    {
        MenuMgr = Managers.GetInstance.MenuMgr;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        MenuMgr.createMenuPause();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        MenuMgr.destroyCurrentMenu();
    }

    public void Menu()
    {
        Time.timeScale = 0;
        Application.LoadLevel(0);
    }

    public void Restart()
    {
        StartGame();
    }

    public void Exit()
    {
        Managers.GetInstance.StorageMgr.writeFile();
        Application.Quit();
    }

    public void Credits()
    {
        MenuMgr.createCredits();
    }

}
