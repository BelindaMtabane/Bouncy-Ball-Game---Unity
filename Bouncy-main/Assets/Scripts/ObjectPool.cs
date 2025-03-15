using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Making a singleton function instance 
    public static ObjectPool Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        InitiatePool();
    }

    //object.InstanceSpawnObject(spawnLocation.position);(Place in the spawn method in bomb spawn 
    //List of objects to store
    //Spawning objects
    //Either static or dynamic size
    //where to spawn the objects

    //Initialize the list of objects to where to spawn objects
    [SerializeField] GameObject spawnable;

    int sizePool = 10;//The amount of objects to store
    List<GameObject> objects = new List<GameObject>();//Create a new list that will store the objects

    public void SpawnObject(Vector3 position)
    {
        //To use the object in unit, we need to get the object from the pool
        var go = GetObject();
        go.SetActive(true);
        go.transform.position = position;//Set it to the position
    }

    GameObject GetObject()
    {
        //loop through the list of objects to see and unused object that can be reused in the object
        for (int i = 0; i < objects.Count - 1; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        //if none of the above are true, then we increase our pool size and add new instatiate 
        sizePool++;

        var go = Instantiate(spawnable);
        go.SetActive(false);
        objects.Add(go);
        return go;
    }
    void InitiatePool()
    {
        //should instatiate and spawn all 10 objects immediately
        for (int i = 0; i < sizePool; i++)
        {
            var go = Instantiate(spawnable);
            go.SetActive(false);
            objects.Add(go);
        }

    }
}
