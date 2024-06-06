using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSpawnKacamata : MonoBehaviour
{
    private ARKacamataManager  kacamataManager;
    
    // Start is called before the first frame update
    void Start()
    {
        kacamataManager = GameObject.FindObjectOfType<ARKacamataManager>();
        if(kacamataManager.currentKacamata != null)
            Spawn(kacamataManager.currentKacamata);
    }
    
    public void Spawn(GameObject obj)
    {
        if (transform.childCount > 0)
        {
            GameObject.Destroy(transform.GetChild(0).gameObject);
            Instantiate(obj, transform.position, transform.rotation, this.transform);
        }
        else
            Instantiate(obj, transform.position, transform.rotation, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
