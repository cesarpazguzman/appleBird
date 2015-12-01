using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manager que gestiona de forma más óptima la creación y destrucción de los objetos.
/// </summary>
public class Spawner : MonoBehaviour
{

    //Diccionario que almacena los objetos desactivados 
    private Dictionary<string, List<GameObject>> m_poolDeactivatedObjects;
    //id único que define al siguiente gameObject que se creara o se sacará del pool, servirá para ponerle un nombre único
    private int m_nextID;


    void Awake()
    {

        m_poolDeactivatedObjects = new Dictionary<string, List<GameObject>>();
        m_nextID = 0;
    }

    // Use this for initialization
    void Start()
    {
        clearPool();
    }

    //Funcion que de forma transparente crea objetos desde cualquier parte del código. Desde esta funcion sacaremos bien el objeto del pool si este
    //se encuentra desactivado, o bien creamos uno nuevo.
    public GameObject createGameObject(GameObject prefab)
    {
        GameObject newObject = null;

        //Si en el pool existe una lista que represente al gameObject a crear
        if (m_poolDeactivatedObjects.ContainsKey(prefab.name.Split('_')[0]))
        {
            List<GameObject> listObjects = m_poolDeactivatedObjects[prefab.name.Split('_')[0]];
            //Si de este tipo de prefab existe alguno desactivado
            if (listObjects.Count > 0)
            {
                //Guardamos la primera aparición del gameObject desactivado que queremos activar
                newObject = listObjects[0];
                //Lo eliminamos
                listObjects.RemoveAt(0);
                //La activamos
                newObject.SetActive(true);
            }
        }

        //Si no había ningún objeto de este tipo en el pool de objetos desactivados entonces tendremos que crearlo
        if (newObject == null)
        {
            //Por tanto creamos uno nuevo
            newObject = GameObject.Instantiate(prefab) as GameObject;
            //Le damos un nombre unico
            newObject.name = prefab.name.Split('_')[0] + "_" + m_nextID++;
        }

        return newObject;
    }

    //Funcion que de forma transparente crea objetos desde cualquier parte del código. Desde esta funcion sacaremos bien el objeto del pool si este
    //se encuentra desactivado, o bien creamos uno nuevo.
    public GameObject createGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = createGameObject(prefab);

        newObject.transform.position = position;
        newObject.transform.rotation = rotation;

        return newObject;
    }

    //Función que simplemente manda al pool de objetos desactivados este objeto
    public void destroyGameObject(GameObject prefab, bool destroy = false)
    {
        if (!destroy)
        {
            //Lo primero que tenemos que hacer es obtener el nombre del prefab original
            string originalPrefabName = prefab.name.Split('_')[0];

            //Para evitar errores, y almacenar ya un GameObject ya desactivado y almacenado, y no tener almacenada varias referencias al mismo
            //se hace esta comprobación
            if (m_poolDeactivatedObjects.ContainsKey(originalPrefabName) && m_poolDeactivatedObjects[originalPrefabName].Contains(prefab)) return;

            //Desactivo el objeto de la escena
            prefab.SetActive(false);

            //Miramos si existe un registro de este objeto en el pool
            if (!m_poolDeactivatedObjects.ContainsKey(originalPrefabName))
            {
                List<GameObject> newList = new List<GameObject>();
                newList.Add(prefab);
                m_poolDeactivatedObjects.Add(originalPrefabName, newList);
            }
            else
            {
                m_poolDeactivatedObjects[originalPrefabName].Add(prefab);
            }
        }
        else
        {
            DestroyObject(prefab);
        }
    }

    //Funcion que vacía todo el pool de objetos desactivados. 
    public void clearPool()
    {
        foreach (List<GameObject> listObject in m_poolDeactivatedObjects.Values)
        {
            foreach (GameObject go in listObject)
            {
                Destroy(go);
            }
            listObject.Clear();
        }
        m_poolDeactivatedObjects.Clear();
    }
}
