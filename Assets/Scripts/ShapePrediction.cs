using Newtonsoft.Json;
using System;

[Serializable]
public class ShapePrediction
{
    [JsonProperty("class")]
    public string Shape { get; set; }
    public float Confidence { get; set; }
}
