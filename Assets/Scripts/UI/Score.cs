using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Managers.GetInstance.GameMgr.textScore = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
