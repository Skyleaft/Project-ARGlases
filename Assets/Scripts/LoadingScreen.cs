using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public int second;
    public string NextScene;
    private ARKacamataManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindObjectOfType<ARKacamataManager>();
        StartCoroutine(loading());
    }
    

    IEnumerator loading()
    {
        
        yield return new WaitForSeconds(second);
        _manager.LoadScene(NextScene);
    }
}
