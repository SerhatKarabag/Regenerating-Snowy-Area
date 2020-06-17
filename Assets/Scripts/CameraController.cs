using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform SnowballTransform;
    public Transform DefaultCamTransform;
    [SerializeField] private static Vector3 newCamPos;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private Vector3 _defaultOffset;
    [SerializeField] private static Quaternion camTurnAngle;
    [SerializeField] private const float Smooth = 0.2f;
    [SerializeField] private const float RotationsSpeed = 3.0f;

    private void OnEnable() {
    
        _cameraOffset = transform.position - SnowballTransform.position;
        _defaultOffset = _cameraOffset;
    }
    void LateUpdate () {

        DefaultCamTransform.position = SnowballTransform.position + _defaultOffset;
        if (Input.GetMouseButton(0))
        {
            camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
            transform.LookAt(SnowballTransform);
            newCamPos = SnowballTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newCamPos, Smooth);
        }
        else
        {
            _cameraOffset = _defaultOffset;
            newCamPos = DefaultCamTransform.position;
            transform.position = Vector3.Slerp(transform.position, newCamPos, Smooth);
            transform.rotation = DefaultCamTransform.rotation;
        }
        
    }
}
