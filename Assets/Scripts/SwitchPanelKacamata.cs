using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanelKacamata : MonoBehaviour
{
    public GameObject AllContentScroll;

    public GameObject RekomenContentScroll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BrowseAllView()
    {
        AllContentScroll.SetActive(true);
        RekomenContentScroll.SetActive(false);
    }

    public void RekomenView()
    {
        AllContentScroll.SetActive(false);
        RekomenContentScroll.SetActive(true);
    }
}
