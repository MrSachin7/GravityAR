using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager)),
RequireComponent(typeof(ARPlaneManager))]
public class PlaceObjects : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float heightOffset = 0.5f;
    private ARRaycastManager aRRayCastManager;
    private ARPlaneManager aRPlaneManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Dictionary<GameObject, Planet> gameObjectToPlanet = new Dictionary<GameObject, Planet>();
    private bool allowSpawn = false;
    private Planet nextPlanetToSpawn = Planet.DefaultPlanet;


    private void Awake()
    {
        aRRayCastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }


    public void AllowSpawn(Planet planet)
    {
        nextPlanetToSpawn = planet;
        allowSpawn = true;

    }

    public void FallAllObjects()
    {
        foreach (var kvp in gameObjectToPlanet)
        {
            GameObject gameObject = kvp.Key;
            Planet planet = kvp.Value;
            gameObject.GetComponent<ConstantForce>().force = new Vector3(0, -planet.GravityStrength, 0);
        }
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        if (!allowSpawn) return;
        if (finger.index != 0) return;
        if (aRRayCastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            Vector3 spawnPosition = hitPose.position + new Vector3(0, heightOffset, 0);

            GameObject gameObject = Instantiate(objectToSpawn, spawnPosition, hitPose.rotation);
            gameObjectToPlanet.Add(gameObject, nextPlanetToSpawn);
            // Disable gravity initially.
            Rigidbody ballRigidbody = gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.useGravity = false;
            }
            allowSpawn = false;
        }
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();

        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;

    }



}
