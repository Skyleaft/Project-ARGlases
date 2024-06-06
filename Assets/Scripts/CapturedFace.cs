using UnityEngine;

public class CapturedFace : MonoBehaviour
{
    public Texture2D currentTexture;
    [SerializeField]
    public ShapePrediction shapePrediction;
    [SerializeField]
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
