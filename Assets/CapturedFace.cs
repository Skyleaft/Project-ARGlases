using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CapturedFace : MonoBehaviour
{
    public byte[] ImageData;
    public Texture2D currentTexture;
    public ShapePrediction prediction;
    public FaceMedia FaceMedia;
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
