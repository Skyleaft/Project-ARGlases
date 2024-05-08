using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeFirstObject : MonoBehaviour
{
    public GlasesContent content;
    // Start is called before the first frame update
    void Start()
    {
        content.SpawnKacamata();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
