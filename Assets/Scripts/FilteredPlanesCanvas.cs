using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredPlanesCanvas : MonoBehaviour
{
    [SerializeField] private Toggle horizontalPlaneToggle;
    [SerializeField] private Toggle bigPlaneToggle;
    [SerializeField] private Button startButton;


    public bool HorizontalPlaneToggle
    {
        get => horizontalPlaneToggle.isOn;
        set
        {
            horizontalPlaneToggle.isOn = value;
            CheckIfStartButtonShouldBeInteractable();
        }
    }
    public bool BigPlaneToggle
    {
        get => bigPlaneToggle.isOn;
        set
        {
            bigPlaneToggle.isOn = value;
            CheckIfStartButtonShouldBeInteractable();
        }
    }

    private ARFilteredPlanes arFilteredPlanes;
   [SerializeField] private ParameterCanvasManager parameterCanvasManager;


    private void OnEnable()
    {
        arFilteredPlanes = FindObjectOfType<ARFilteredPlanes>();
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {

        arFilteredPlanes.OnHorizontalPlaneFound += HorizontalPlaneFound;
        arFilteredPlanes.OnBigPlaneFound += BigPlaneFound;
    }


    private void UnSubscribeEvents()
    {

        arFilteredPlanes.OnHorizontalPlaneFound -= HorizontalPlaneFound;
        arFilteredPlanes.OnBigPlaneFound -= BigPlaneFound;
    }

    private void HorizontalPlaneFound()
    {
        HorizontalPlaneToggle = true;
    }

    private void BigPlaneFound()
    {
        BigPlaneToggle = true;
    }


    private void CheckIfStartButtonShouldBeInteractable()
    {
        startButton.interactable = HorizontalPlaneToggle && BigPlaneToggle;
    }

    public void StartButtonClicked()
    {
        gameObject.SetActive(false);
        parameterCanvasManager.EnableCanvas();
    }
}
