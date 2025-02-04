﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveZoomStrategy : ZoomStrategy
{
    Vector3 normalizedCameraPosition;
    float currentZoomLevel;

    public PerspectiveZoomStrategy(Camera cam, Vector3 offset, float startingZoom)
    {
        normalizedCameraPosition = new Vector3(0f, Mathf.Abs(offset.y), -Mathf.Abs(offset.x)).normalized;
        currentZoomLevel = startingZoom;
        PositionCamera(cam);
    }

    private void PositionCamera(Camera cam)
    {
        cam.transform.localPosition = normalizedCameraPosition * currentZoomLevel;
    }

    public void Zoomin(Camera cam, float delta, float nearZoomLimit)
    {
        if (currentZoomLevel <= nearZoomLimit) return;
        currentZoomLevel = Mathf.Max(currentZoomLevel - delta, nearZoomLimit);
        PositionCamera(cam);
    }

    public void Zoomout(Camera cam, float delta, float farZoomLimit)
    {
        if (currentZoomLevel >= farZoomLimit) return;
        currentZoomLevel = Mathf.Min(currentZoomLevel + delta, farZoomLimit);
        PositionCamera(cam);
    }
}
