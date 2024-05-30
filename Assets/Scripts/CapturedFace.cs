using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class CapturedFace : MonoBehaviour
{
    public byte[] ImageData;
    public Texture2D currentTexture;
    public ShapePrediction shapePrediction;
    public GenderPrediction genderPrediction;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("FaceImage");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
}
