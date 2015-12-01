using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Componente que va al botón de Sound/MUTE. Sirve para silenciar o activar el sonido
/// </summary>
public class Sound : MonoBehaviour {

    bool isSound = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void touchSound()
    {
        isSound = !isSound;
        this.gameObject.GetComponent<Text>().text = (isSound) ? "MUTE" : "SOUND";
        AudioListener.volume = (isSound) ? 1 : 0;
    }
}
