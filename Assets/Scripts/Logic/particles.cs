using UnityEngine;
using System.Collections;

/// <summary>
/// Componente que colocamos en las particulas. Sirve para desactivarlas después de que se activen. 
/// </summary>
public class particles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        StartCoroutine(deactivateParticle());
    }

    void OnDisable()
    {
        StopCoroutine(deactivateParticle());
    }

	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator deactivateParticle()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
    
}
