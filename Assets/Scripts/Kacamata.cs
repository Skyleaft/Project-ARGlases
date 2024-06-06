using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObject/Kacamata", fileName = "Kacamata")]
public class Kacamata : ScriptableObject
{
    [Header("Property")]
    public string Nama;
    [FormerlySerializedAs("Ukuran")] public string Seri;
    public Color Warna;
    public GameObject Prefab;
    public Sprite Preview;

    [Header("Face Attribute")]
    public Gender Gender;
    [Range(0f, 1f)]
    public float Oval;
    [Range(0f, 1f)]
    public float Square;
    [Range(0f, 1f)]
    public float Oblong;
    [Range(0f, 1f)]
    public float Round;
}

public enum Gender { Pria, Wanita,Unisex }

