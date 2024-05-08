using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitARKacamata : MonoBehaviour
{
    public GameObject currentKacamata;
    private ARFaceManager faceManager;
    // Start is called before the first frame update
    void Start()
    {
        var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        currentKacamata = manager.currentKacamata;
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facePrefab = currentKacamata;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
