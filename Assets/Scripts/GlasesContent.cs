using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GlasesContent : MonoBehaviour
{
    [Header("Setter Property")]
    public TextMeshProUGUI tbrand;
    public TextMeshProUGUI tseri;
    public Image objColor;
    public Image objPreview;

    [Header("Content")]
    public Kacamata kacamata;
    // Start is called before the first frame update
    void Start()
    {
        tbrand.text = kacamata.Nama;
        tseri.text = kacamata.Seri;
        objColor.color = kacamata.Warna;
        objPreview.sprite = kacamata.Preview;
    }
    
    public void SpawnKacamata()
    {
        var manager = GameObject.FindObjectOfType<ARKacamataManager>();
        var colorChanger = kacamata.Prefab.GetComponent<ColorKacamata>();
        colorChanger.ChangeColor(kacamata.Warna);
        manager.currentKacamata = kacamata.Prefab;
        var spawner = GameObject.FindObjectOfType<ARSpawnKacamata>();
        if(spawner!=null)
            spawner.Spawn(kacamata.Prefab);
        // var faceManager = GameObject.FindObjectOfType<ARFaceManager>();
        //
        // foreach (var item in faceManager.trackables)
        // {
        //     DestroyImmediate(item.gameObject);
        // }
        // faceManager.facePrefab = kacamata.Prefab;
        
        
    }

}
