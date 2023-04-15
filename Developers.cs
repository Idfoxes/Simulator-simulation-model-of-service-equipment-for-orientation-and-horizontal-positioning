using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Developers : MonoBehaviour
{
    public GameObject developers;
    private void Update()
    {
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.D))
        {
            developers.SetActive(true);
        }
        else
            developers.SetActive(false);
    }
}
