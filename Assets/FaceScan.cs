using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FaceScan : MonoBehaviour
{
    public byte[] currentPhoto;
    public Texture2D currentTexture;
    public Prediction prediction;
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
