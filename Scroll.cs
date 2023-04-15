using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Scroll : MonoBehaviour
{
    public RectTransform txtRT;
    public RectTransform contentRT;


        private void Update()
    {
        var size = contentRT.sizeDelta;
        size.y = txtRT.sizeDelta.y;
        contentRT.sizeDelta = size;
    }
}
