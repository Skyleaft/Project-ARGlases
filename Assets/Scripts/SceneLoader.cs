using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string LoadSceneName;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        var manager = FindObjectOfType<ARKacamataManager>();
        button.onClick.AddListener(() =>
        {
            manager.LoadScene(LoadSceneName);
        });
    }
    
}
