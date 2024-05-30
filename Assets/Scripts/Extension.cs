using System.IO;
using System;
using UnityEngine;

public static class Extension
{
    public static Texture2D GetReadableTexture2d(Texture texture)
    {
        var tmp = RenderTexture.GetTemporary(
            texture.width,
            texture.height,
            32
        );
        Graphics.Blit(texture, tmp);

        var previousRenderTexture = RenderTexture.active;
        RenderTexture.active = tmp;

        var texture2d = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        texture2d.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2d.Apply();
        texture2d.name = "temp";
        RenderTexture.active = previousRenderTexture;
        RenderTexture.ReleaseTemporary(tmp);
        return texture2d;
    }

    public static Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D dest = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        dest.Apply(false);
        Graphics.CopyTexture(rTex, dest);
        return dest;
    }

    public static string ConvertTextureToJson(Texture2D tex)
    {
        string TextureArray = Convert.ToBase64String(tex.EncodeToPNG());
        string jsonOutput = JsonUtility.ToJson(new StoreJson(TextureArray));
        return jsonOutput;
    }

    public static void SaveImage(Texture2D texture)
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
