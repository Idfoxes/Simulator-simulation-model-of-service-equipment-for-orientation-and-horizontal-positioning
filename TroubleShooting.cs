using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroubleShooting : MonoBehaviour
{
    public GameObject bt;
    public GameObject[] Panel;


    public void ViewPanel(GameObject panel)
    {
        bt.SetActive(false);
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        bt.SetActive(true);
        panel.SetActive(false);
    }
    
}
