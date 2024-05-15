using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlasesContent : MonoBehaviour
{
    [Header("Setter Property")]
    public TextMeshProUGUI tbrand;
    public TextMeshProUGUI tukuran;
    public Image objColor;
    public Image objPreview;

    [Header("Content")]
    public Kacamata kacamata;
    // Start is called before the first frame update
    void Start()
    {
        tbrand.text = kacamata.Nama;
        tukuran.text = kacamata.Ukuran;
        objColor.color = kacamata.Warna;
        objPreview.sprite = kacamata.Preview;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnKacamata()
    {
        var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        var colorChanger = kacamata.Prefab.GetComponent<ColorKacamata>();
        colorChanger.ChangeColor(kacamata.Warna);
        manager.currentKacamata = kacamata.Prefab;
        var spawner = GameObject.FindObjectOfType<GlassSpawner>();
        spawner.Spawn(kacamata.Prefab);
    }

}
