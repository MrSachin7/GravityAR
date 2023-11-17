using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlanes : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private Vector2 minDimensionForBigPlane;

    public event Action OnHorizontalPlaneFound;
    public event Action OnBigPlaneFound;
    private List<ARPlane> planes;

    void OnEnable()
    {
        planes = new List<ARPlane>();
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {

        if (args.added == null || args.added.Count == 0)
        {
            return;
        }

        planes.AddRange(args.added);

        foreach (ARPlane plane in planes.Where(plane => plane.extents.x * plane.extents.y > 0.1f))
        {
            if (!plane.alignment.IsHorizontal()) continue;

            OnHorizontalPlaneFound?.Invoke();

            if (plane.extents.x > minDimensionForBigPlane.x && plane.extents.y > minDimensionForBigPlane.y)
            {
                OnBigPlaneFound?.Invoke();
            }
        }

    }
}
