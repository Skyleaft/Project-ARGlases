using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonPredictionShape
{
    public string time {get;set;}
    public List<ShapePrediction> predictions { get; set; }

}
[Serializable]
public class JsonPredictionGender
{
    public string time { get; set; }
    public List<GenderPrediction> predictions { get; set; }

}
