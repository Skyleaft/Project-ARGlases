using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorKacamata : MonoBehaviour
{
    public List<Material> materials;
    public Color Warna;
    

    public void ChangeColor(Color _warna)
    {
        this.Warna = _warna;
        foreach (Material mat in materials)
        {
            mat.color = Warna;
        }
    }
}
