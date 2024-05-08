using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlasesContent : MonoBehaviour
{
    public TextMeshProUGUI tbrand;
    public TextMeshProUGUI tukuran;

    public string brand;
    public string ukuran;
    public Color warna;

    public GameObject kacamata;
    // Start is called before the first frame update
    void Start()
    {
        tbrand.text = brand;
        tukuran.text = ukuran;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnKacamata()
    {
        var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        manager.currentKacamata = kacamata;
        var spawner = GameObject.FindObjectOfType<GlassSpawner>();
        spawner.Spawn(kacamata);
    }

}
