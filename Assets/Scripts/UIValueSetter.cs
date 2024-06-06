using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIValueSetter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI shapeText;
    private CapturedFace _capturedFace;
    
    void Awake()
    {
        _capturedFace = GameObject.FindObjectOfType<CapturedFace>();
        if (_capturedFace != null)
        {
            shapeText.text = _capturedFace.shapePrediction.Shape;
        }
    }
    
}
