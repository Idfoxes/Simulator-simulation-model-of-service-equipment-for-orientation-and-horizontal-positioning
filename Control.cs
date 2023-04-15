using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
   public void OpenScene (int index)
    {
        SceneManager.LoadScene (index);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
