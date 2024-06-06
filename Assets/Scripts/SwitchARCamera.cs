using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SwitchARCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private ARCameraManager _cameraManager;
    void Start()
    {
        _cameraManager = GameObject.FindObjectOfType<ARCameraManager>();
    }
    
    public void Switch()
    {
        if(_cameraManager.currentFacingDirection==CameraFacingDirection.User)
        {
            _cameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }
        else
        {
            _cameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
