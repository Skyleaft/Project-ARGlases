using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PredictFace : MonoBehaviour
{
    public bool isPredicting;
    public GameObject LoadingCanvas;
    public SetDetectionRes uiSet;
    private void Awake()
    {
        LoadingCanvas.gameObject.SetActive(true);
        isPredicting = true;
        StartCoroutine(GetPrediction());
    }
    void Start()
    {

    }
    public void Update()
    {

    }

    IEnumerator GetPrediction()
    {
        var capturedFace = GameObject.FindObjectOfType<CapturedFace>();
        yield return new WaitForSeconds(1);
        if (capturedFace != null)
        {
            capturedFace.ImageData = capturedFace.currentTexture.EncodeToJPG();

            string api_key = "L75XrcNlzkxRdrmDLQlz";
            string DATASET_NAME = "face-shape-detection";
            string uploadURL = $"https://detect.roboflow.com/{DATASET_NAME}/1?api_key={api_key}&confidence=0.01";

            var postData = Convert.ToBase64String(capturedFace.ImageData);
            byte[] data = Encoding.UTF8.GetBytes(postData);

            //send alternate request
            yield return GetPredictAlternate(postData);

            //send request
            UnityWebRequest www = new UnityWebRequest(uploadURL, "POST")
            {
                uploadHandler = new UploadHandlerRaw(data),
                downloadHandler = new DownloadHandlerBuffer()
            };
            www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return www.SendWebRequest();

            // Get Response
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
                Debug.LogError(www.error);
            }
            else
            {
                var responseContent = www.downloadHandler.text;
                Debug.Log(responseContent);
                var res = JsonConvert.DeserializeObject<JsonPrediction>(responseContent);
                Debug.Log(res);
                capturedFace.prediction = res.predictions.FirstOrDefault();
            }
            www.Dispose();
        }
        uiSet.SetUIValue(capturedFace);
        yield return new WaitForSeconds(1);
        LoadingCanvas.SetActive(false);
    }

    IEnumerator GetPredictAlternate(string imageData)
    {
        var capturedFace = GameObject.FindObjectOfType<CapturedFace>();
        var apiURL = "https://www.betafaceapi.com/api/v2/media";

        var requestPost = new BetaFaceRequest()
        {
            api_key = "d45fd466-51e2-4701-8da8-04351c872236",
            detection_flags = "cropface,recognition,classifiers",
            file_base64 = imageData,
            original_filename = "images.jpeg"
        };
        using UnityWebRequest www = UnityWebRequest.Post(apiURL,
            JsonConvert.SerializeObject(requestPost),
            "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.downloadHandler.text);
            Debug.LogError(www.error);
        }
        else
        {
            var res = JsonConvert.DeserializeObject<BetaFace>(www.downloadHandler.text);
            capturedFace.FaceMedia = res.media;
            Debug.Log(www.downloadHandler.text);
        }
    }

    public class BetaFaceRequest
    {
        public string api_key;
        public string detection_flags;
        public string file_base64;
        public string original_filename;
    }

}
