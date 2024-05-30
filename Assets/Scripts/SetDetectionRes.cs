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
            if (faces.shapePrediction != null)
            {
                shape.text = faces.shapePrediction.Shape;
                var percent = faces.shapePrediction.Confidence * 100f;
                shapepercent.text = percent.ToString("0.00") + "%";
                shapeslider.value = faces.shapePrediction.Confidence;
            }
            if (faces.genderPrediction != null)
            {
                string gendertext = "";
                if (faces.genderPrediction.Gender.Contains("Male"))
                    gendertext = "Male";
                else if (faces.genderPrediction.Gender.Contains("Female"))
                    gendertext = "Female";
                else
                    gendertext = "Male";
                gender.text = gendertext;
                var percent = faces.genderPrediction .Confidence * 100f;
                genderpercent.text = percent.ToString("0.00") + "%";
                genderslider.value = faces.genderPrediction.Confidence;
            }
        }
    }
}
