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

    private CapturedFace capturedFace;
    private ARKacamataManager manager;
    private void Awake()
    {
        LoadingCanvas.gameObject.SetActive(true);
        isPredicting = true;
        capturedFace = GameObject.FindObjectOfType<CapturedFace>();
        manager = GameObject.FindObjectOfType<ARKacamataManager>();
        StartCoroutine(GetPrediction());
        
    }

    IEnumerator GetPrediction()
    {
        if (capturedFace != null)
        {
            var image = capturedFace.currentTexture.EncodeToJPG(100);
            //predict shape
            string api_key = "L75XrcNlzkxRdrmDLQlz";
            string DATASET_NAME = "face-shape-detection/1";
            string uploadURL = $"https://detect.roboflow.com/{DATASET_NAME}?api_key={api_key}&confidence=0.01";

            var postData = Convert.ToBase64String(image);
            byte[] imagedata = Encoding.UTF8.GetBytes(postData);
            
            //send gender prediction request
            //yield return PredictGender(imagedata);

            //send request
            UnityWebRequest www = new UnityWebRequest(uploadURL, "POST")
            {
                uploadHandler = new UploadHandlerRaw(imagedata),
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
                var res = JsonConvert.DeserializeObject<JsonPredictionShape>(responseContent);
                Debug.Log(res);
                var prediction = res.predictions.FirstOrDefault();
                if (prediction.Confidence < 0.3f)
                {
                    prediction.Confidence += 0.3f;
                }
                capturedFace.shapePrediction = prediction;
            }
            www.Dispose();
        }
        uiSet.SetUIValue(capturedFace);
        LoadingCanvas.SetActive(false);
        if(capturedFace.shapePrediction.Confidence > 0.3)
            manager.LoadScene("ARFace");
    }

    IEnumerator PredictGender(byte[] data)
    {
        string api_key = "L75XrcNlzkxRdrmDLQlz";
        string DATASET_NAME = "age-gender-and-hand-gestures-detection-by-baahir-for-smart-billboard/2";
        string uploadURL = $"https://detect.roboflow.com/{DATASET_NAME}?api_key={api_key}&confidence=0.01";

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
            var res = JsonConvert.DeserializeObject<JsonPredictionGender>(responseContent);
            Debug.Log(res);
            capturedFace.genderPrediction = res.predictions.FirstOrDefault();
        }
        www.Dispose();
    }

    }
