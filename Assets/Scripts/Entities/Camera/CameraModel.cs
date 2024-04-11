using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel
{
    public float speed;
    public float smoothSpeed;
    public GameObject prefab;
    public Transform target;
    public GameObject miniMapCamera;
    public RectTransform Border;

    public CameraModel(CameraData data, Transform _target)
    {
        speed = data.speed;
        smoothSpeed = data.smoothSpeed;
        prefab = GameObject.Instantiate(data.prefab);
        target = _target;
    }
}
