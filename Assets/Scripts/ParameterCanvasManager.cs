using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterCanvasManager : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject parameterButton;
    [SerializeField] private GameObject doneButton;





    public void EnableCanvas()
    {
        gameObject.SetActive(true);
    }

    public void ParameterButtonPressed()
    {
        panel.SetActive(true);
        parameterButton.SetActive(false);
    }

    public void DoneButtonPressed()
    {
        panel.SetActive(false);
        parameterButton.SetActive(true);
    }

}
