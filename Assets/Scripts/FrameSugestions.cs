using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrameSugestions : MonoBehaviour
{
    public GameObject CardTemplate;
    public RectTransform SpawnContent;
    public List<Kacamata> ListDataKacamata;

    public List<GlasesContent> ListGlasesContents;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in ListDataKacamata)
        {
            SpawnGlassContent(CardTemplate, item);
        }

        if (ListGlasesContents.Count > 0)
        {
            //ListGlasesContents.FirstOrDefault().SpawnKacamata();
        }
    }

    public void SpawnGlassContent(GameObject obj, Kacamata kacamata)
    {
        var initContent = obj.GetComponent<GlasesContent>();
        initContent.kacamata = kacamata;
        obj.name = kacamata.name;
        var contentobj = Instantiate(obj,SpawnContent);
        var content = contentobj.GetComponent<GlasesContent>();
        ListGlasesContents.Add(content);
        
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
