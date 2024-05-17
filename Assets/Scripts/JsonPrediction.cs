using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonPrediction
{
    public string time {get;set;}
    public List<ShapePrediction> predictions { get; set; }

}
