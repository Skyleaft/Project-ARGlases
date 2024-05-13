using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlasesContent : MonoBehaviour
{
    public TextMeshProUGUI tbrand;
    public TextMeshProUGUI tukuran;
    public Image objColor;
    public Image objPreview;

    public string brand;
    public string ukuran;
    public Color warna;
    public Sprite PreviewImage;

    public GameObject kacamata;
    // Start is called before the first frame update
    void Start()
    {
        tbrand.text = brand;
        tukuran.text = ukuran;
        objColor.color = warna;
        objPreview.sprite = PreviewImage;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnKacamata()
    {
        var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        var colorChanger = kacamata.GetComponent<ColorKacamata>();
        colorChanger.ChangeColor(warna);
        manager.currentKacamata = kacamata;
        var spawner = GameObject.FindObjectOfType<GlassSpawner>();
        spawner.Spawn(kacamata);
    }

}
