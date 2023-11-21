using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject objectsToSpawn;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private Dictionary<GameObject, Planet> spawnedObjectToPlanet = new Dictionary<GameObject, Planet>();



    public void SpawnObject(Planet planet)
    {
        Transform spawnPoint = spawnPoints[spawnedObjects.Count];
        GameObject spawnedObject = Instantiate(objectsToSpawn, spawnPoint.position, Quaternion.identity);
        spawnedObject.AddComponent<ConstantForce>().force = new Vector3(0, -planet.GravityStrength, 0);

        spawnedObjects.Add(spawnedObject);
    }

}
