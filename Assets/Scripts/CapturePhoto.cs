using UnityEngine;
using UnityEngine.UI;

public class CapturePhoto : MonoBehaviour
{

    public RawImage capturer;

    private void Start()
    {
    }

    public void Take()
    {

        var tex = Extension.GetReadableTexture2d(capturer.texture);
        Extension.SaveImage(tex);
        var captured = FindObjectOfType<CapturedFace>();
        captured.currentTexture = tex;
        //faceImage.Shape = responseContent;

        var manager = FindObjectOfType<ARKacamataManager>();
        manager.LoadScene("CaptureResult");

    }


}


