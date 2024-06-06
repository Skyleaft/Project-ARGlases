using Newtonsoft.Json;
using System;

[Serializable]
public class ShapePrediction
{
    [JsonProperty("class")] 
    public string Shape;
    public float Confidence;
}
