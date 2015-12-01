using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Componente que sirve para indicarle al StorageMgr el texto correspondiente al best Score
/// </summary>
public class BestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Managers.GetInstance.StorageMgr.textBestScore = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
