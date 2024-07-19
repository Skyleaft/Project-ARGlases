using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class FrameSugestions : MonoBehaviour
{
    public GameObject CardTemplate;
    public RectTransform SpawnContent;
    public RectTransform SpawnContentAll;
    public List<Kacamata> ListDataKacamata;

    public List<GlasesContent> ListGlasesContents;
    public List<GlasesContent> ListGlasesContentsAll;

    private CapturedFace capturedFace;
    // Start is called before the first frame update
    void Start()
    {
        capturedFace = GameObject.FindObjectOfType<CapturedFace>();
        foreach (var item in ListDataKacamata)
        {
            bool genderValid=false;
            bool shapeValid = false;
            List<string> validShapes = new List<string>();
            // if (item.Gender == Gender.Unisex)
            //     genderValid = true;
            // var isFemale = capturedFace.genderPrediction.Gender.Contains("Wanita");
            // if (item.Gender == Gender.Wanita && isFemale)
            //     genderValid = true;
            // if (item.Gender == Gender.Pria && !isFemale)
            //     genderValid = true;
            if(item.Oval==1f)
                validShapes.Add("oval");
            if(item.Oblong==1f)
                validShapes.Add("oblong");
            if(item.Round==1f)
                validShapes.Add("round");
            if(item.Square==1f)
                validShapes.Add("square");
            if(item.Heart==1f)
                validShapes.Add("heart");

            if (validShapes.Contains(capturedFace.shapePrediction.Shape))
                shapeValid = true;
            
            if(shapeValid)
                SpawnGlassContent(CardTemplate, item);
            
            SpawnGlassContentAll(CardTemplate,item);
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
    
    public void SpawnGlassContentAll(GameObject obj, Kacamata kacamata)
    {
        var initContent = obj.GetComponent<GlasesContent>();
        initContent.kacamata = kacamata;
        obj.name = kacamata.name;
        var contentobj = Instantiate(obj,SpawnContentAll);
        var content = contentobj.GetComponent<GlasesContent>();
        ListGlasesContentsAll.Add(content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
