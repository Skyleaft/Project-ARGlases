using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitARKacamata : MonoBehaviour
{
    public GameObject currentKacamata;
    private ARFaceManager faceManager;
    public TextMeshProUGUI textdebug;

    public int countTrackable;
    // Start is called before the first frame update
    void Start()
    {
        // var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        // currentKacamata = manager.currentKacamata;
        faceManager = GetComponent<ARFaceManager>();
        
        // faceManager.facePrefab = currentKacamata;
    }

    private void Update()
    {
        countTrackable = faceManager.trackables.count;
        textdebug.text = countTrackable.ToString();
    }
}
