using Newtonsoft.Json;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDetectionRes : MonoBehaviour
{
    [Header("shape")]
    public TextMeshProUGUI shape;
    public TextMeshProUGUI shapepercent;
    public Slider shapeslider;

    [Header("gender")]
    public TextMeshProUGUI gender;
    public TextMeshProUGUI genderpercent;
    public Slider genderslider;

    [Header("age")]
    public TextMeshProUGUI age;
    public TextMeshProUGUI agepercent;
    public Slider ageslider;

    public Image Image;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetUIValue(CapturedFace faces)
    {
        if (faces != null)
        {
            Image.sprite = Sprite.Create(faces.currentTexture, new Rect(0.0f, 0.0f, faces.currentTexture.width, faces.currentTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            if (faces.prediction != null)
            {
                shape.text = faces.prediction.Shape;
                var percent = faces.prediction.Confidence * 100f;
                shapepercent.text = percent.ToString("0.00") + "%";
                shapeslider.value = faces.prediction.Confidence;
            }
            if (faces.FaceMedia != null)
            {
                var testgender = JsonConvert.SerializeObject(faces.FaceMedia);
                Debug.Log(testgender);
                var gendertag = faces.FaceMedia.faces
                    .FirstOrDefault()
                    .tags
                    .Where(c => c.name == "gender")
                    .FirstOrDefault();
                gender.text = gendertag.value;
                genderslider.value = gendertag.confidence;
                genderpercent.text = gendertag.confidence.ToString("0.00") + "%";

                var agetag = faces.FaceMedia.faces
                    .FirstOrDefault()
                    .tags
                    .Where(c => c.name == "age")
                    .FirstOrDefault();
                age.text = agetag.value;
                ageslider.value = agetag.confidence;
                agepercent.text = agetag.confidence.ToString("0.00") + "%";
            }
        }
    }
}
