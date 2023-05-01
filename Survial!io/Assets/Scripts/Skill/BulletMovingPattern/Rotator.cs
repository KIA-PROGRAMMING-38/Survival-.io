using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotationSpeed { get; set; } = 100f;

    private static readonly Vector3 BACK = Vector3.back;
    private Transform _pointTransform;

    public void Move()
    {        
        transform.RotateAround(_pointTransform.position, BACK, RotationSpeed * Time.deltaTime);        
    }

    public void SetPointTransform(Transform pointTransform)
    {
        _pointTransform = pointTransform;        
    }

    private void Start()
    {
        _pointTransform = GameManager.Instance.Player.transform;        
    }

    private void Update()
    {        
        Move();
    }
}
