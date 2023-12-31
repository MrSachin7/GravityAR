using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelectionCanvasManager : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject addBallButton;
    [SerializeField] private PlaceObjects placeObjectsManager;

    private int dropdownValue = 0;


    public void EnableCanvas()
    {
        gameObject.SetActive(true);
    }

    public void FallButtonPressed(){
       placeObjectsManager.FallAllObjects();
    }

    public void AddBallButtonPressed()
    {
        panel.SetActive(true);
        addBallButton.SetActive(false);
    }

    public void SetDropdownValue(int value)
    {
        dropdownValue = value;
    }


    public void AddBallPressedInsideCanvas()
    {
        panel.SetActive(false);
        addBallButton.SetActive(true);
        Planet.PlanetName selectedPlanet = (Planet.PlanetName)dropdownValue;
        Planet planet = new Planet()
        {

            PlanetType = selectedPlanet
        };
        Debug.Log("PlanetType: " + planet.PlanetType);
        Debug.Log("GravityStrength: " + planet.GravityStrength);

        placeObjectsManager.AllowSpawn(planet);

    }

}
