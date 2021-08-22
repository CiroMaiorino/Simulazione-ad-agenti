using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveZoomStategy : IZoomStrategy
{
    Vector3 normalizedCameraPosition;
    float currentZoomLevel;

    public PerspectiveZoomStategy(Camera cam, Vector3 offset, float startingZoom)
    {
        normalizedCameraPosition = new Vector3(0f, Mathf.Abs(offset.y), -Mathf.Abs(offset.x)).normalized;
        currentZoomLevel = startingZoom;
        PositionCamera(cam);

    }

    private void PositionCamera(Camera cam)
    {
        cam.transform.localPosition = normalizedCameraPosition * currentZoomLevel;
    }

    public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
    {
        Debug.LogError(currentZoomLevel);
        if (currentZoomLevel <= nearZoomLimit) return;
        currentZoomLevel = Mathf.Max(currentZoomLevel - delta, nearZoomLimit);
        PositionCamera(cam);
    }

    public void ZoomOut(Camera cam, float delta, float farZoomLimit)
    {
        Debug.LogError(currentZoomLevel);
        if (currentZoomLevel >= farZoomLimit) return;
        currentZoomLevel = Mathf.Min(currentZoomLevel + delta, farZoomLimit);
        PositionCamera(cam);
    }
}
