using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKacamata : MonoBehaviour
{
    private ARKacamataManager kacamataManager;

    public void Clear()
    {
        kacamataManager = FindObjectOfType<ARKacamataManager>();
        kacamataManager.ClearKacamata();
    }
}
