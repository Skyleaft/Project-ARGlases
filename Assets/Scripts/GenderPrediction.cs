using Newtonsoft.Json;
using System;


[Serializable]
public class GenderPrediction
{
    [JsonProperty("class")]
    public string Gender;
    public float Confidence;
}
