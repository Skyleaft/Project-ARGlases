using UnityEngine;
using UnityEngine.SceneManagement;

public class ARKacamataManager : MonoBehaviour
{
    public GameObject currentKacamata;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ARManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    
}
