using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController
{
    private CameraModel model;
    private Vector3 vector;
    public CameraController(CameraModel _model)
    {
        model = _model;
        vector = Vector3.zero;
    }

    public void Updating()
    {

    }

    public void FixedUpdating()
    {
        moveCameras();
    }

    public void LateUpdating()
    {

    }

    private void moveCameras()
    {
        if(model.target != null)
        {
            model.prefab.transform.position = Vector3.SmoothDamp(model.prefab.transform.position, model.target.position, ref vector, 0.0025f);
        }
    }

}