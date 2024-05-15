using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDetectionRes : MonoBehaviour
{
    [Header("setter")]
    public TextMeshProUGUI shape;
    public TextMeshProUGUI confidence;
    public Image Image;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        var faces = FindObjectOfType<FaceScan>();
        if (faces != null)
        {
            Image.sprite = Sprite.Create(faces.currentTexture, new Rect(0.0f, 0.0f, faces.currentTexture.width, faces.currentTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            if (faces.prediction != null){
                shape.text = faces.prediction.Shape;
                var percent = faces.prediction.Confidence * 100f;
                confidence.text = percent.ToString("0.00")+"%";
                slider.value = faces.prediction.Confidence;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
