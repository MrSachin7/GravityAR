using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnTransform;
    [SerializeField] private GameObject spawnObject;

    private Dictionary<GameObject, Planet> gameObjectToPlanet = new Dictionary<GameObject, Planet>();





    public void SpawnBall(Planet planet)
    {
        int spawnIndex = gameObjectToPlanet.Count % spawnTransform.Length;
        GameObject spawnedObject = Instantiate(spawnObject, spawnTransform[spawnIndex].position, Quaternion.identity);
        gameObjectToPlanet.Add(spawnedObject, planet);

    }
}
