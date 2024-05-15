using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using TextureSource;
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

        var tex = GetReadableTexture2d(capturer.texture);
        SaveImage(tex);
        var faceImage = FindObjectOfType<FaceScan>();
        faceImage.currentPhoto = tex.EncodeToJPG();

        faceImage.currentTexture = tex;
        string encoded = Convert.ToBase64String(faceImage.currentPhoto);

        byte[] data = Encoding.ASCII.GetBytes(encoded);
        string api_key = "L75XrcNlzkxRdrmDLQlz";
        string DATASET_NAME = "face-shape-detection";
        string uploadURL =$"https://detect.roboflow.com/face-shape-detection/1?api_key={api_key}&confidence=0.01";

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        // Configure Request
        WebRequest request = WebRequest.Create(uploadURL);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        // Write Data
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }

        // Get Response
        string responseContent = null;
        using (WebResponse response = request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr99 = new StreamReader(stream))
                {
                    responseContent = sr99.ReadToEnd();
                }
            }
        }
        Debug.Log(responseContent);
        var res = JsonConvert.DeserializeObject<JsonPrediction>(responseContent);
        Debug.Log(res);
        faceImage.prediction = res.predictions.FirstOrDefault();
        //faceImage.Shape = responseContent;

        var manager = FindObjectOfType<ARKacamataManager>();
        manager.LoadScene("CaptureResult");

    }

    private static Texture2D GetReadableTexture2d(Texture texture)
    {
        var tmp = RenderTexture.GetTemporary(
            texture.width,
            texture.height,
            32
        );
        Graphics.Blit(texture, tmp);

        var previousRenderTexture = RenderTexture.active;
        RenderTexture.active = tmp;

        var texture2d = new Texture2D(texture.width, texture.height,TextureFormat.RGBA32, false);
        texture2d.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2d.Apply();
        texture2d.name = "temp";
        RenderTexture.active = previousRenderTexture;
        RenderTexture.ReleaseTemporary(tmp);
        return texture2d;
    }

    public Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D dest = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        dest.Apply(false);
        Graphics.CopyTexture(rTex, dest);
        return dest;
    }

    private string ConvertTextureToJson(Texture2D tex)
    {
        string TextureArray = Convert.ToBase64String(tex.EncodeToPNG());
        string jsonOutput = JsonUtility.ToJson(new StoreJson(TextureArray));
        return jsonOutput;
    }

    private static void SaveImage(Texture2D texture)
    {
        var imageBytes = texture.EncodeToJPG();

        if (imageBytes.Length == 0)
        {
            //AndroidHelper.LogCat($"Trying to save empty picture. Abort.", Tag);
            return;
        }

        var filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
        var filepath = Path.Combine(Application.persistentDataPath, filename);
        //AndroidHelper.LogCat($"{imageBytes.Length} to {filepath}", Tag);
        try
        {
            File.WriteAllBytes(filepath, imageBytes);
            //AndroidHelper.LogCat("SAVED", Tag);
        }
        catch (Exception e)
        {
            //AndroidHelper.LogCat(e.Message, Tag);
        }
    }
}

public class StoreJson
{
    public string imageFile;
    public StoreJson(string imageFile)
    {
        this.imageFile = imageFile;
    }
}
