using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonoBlock : MonoBehaviour
{
    public GameObject[] AllIndikators;
    public GameObject[] VerticalIndikatorsMinus;
    public GameObject[] VerticalIndikatorsPlus;
    public GameObject[] HorizontalIndikatorsMinus;
    public GameObject[] HorizontalIndikatorsPlus;
    public GameObject HorizontalMachine, VerticalMachine;
    public GameObject SwitchOn, SwitchOff;
    public GameObject ChangePosition;
    public Text HorizontalText, VerticalText;
    public Slider sliderHorizontal, sliderVertical;
    public bool switchActive;
    public int counterHorizontal,counterVertical = 0;
    int Horizontal;
    int Vertical;

    private void Start()
    {
        sliderHorizontal.enabled = false;
        sliderVertical.enabled = false;
    }

    private void Update()
    { 
        IndikatorsCounts();
        Work();
    }

    public void Work()
    {
        Horizontal = Convert.ToInt32(sliderHorizontal.value);
        Vertical = Convert.ToInt32(sliderVertical.value);
        if (switchActive)
        {
            if (Horizontal > counterHorizontal && counterHorizontal >= 0)
            {
                counterHorizontal = Convert.ToInt32(sliderHorizontal.value);
                HorizontalIndikatorsPlus[counterHorizontal -  1].SetActive(true);
                HorizontalMachine.transform.rotation = Quaternion.Euler(0, 0, -sliderHorizontal.value);
            }
            else if (Horizontal < counterHorizontal && counterHorizontal >= 1)
            {
                counterHorizontal = Convert.ToInt32(sliderHorizontal.value);
                HorizontalIndikatorsPlus[counterHorizontal].SetActive(false);
                HorizontalMachine.transform.rotation = Quaternion.Euler(0, 0, -sliderHorizontal.value);
            }
            
            if (Horizontal < counterHorizontal)
            {
                counterHorizontal = Convert.ToInt32(sliderHorizontal.value);
                HorizontalIndikatorsMinus[counterHorizontal + 4].SetActive(true);
                HorizontalMachine.transform.rotation = Quaternion.Euler(0, 0, -sliderHorizontal.value);
            }
            else if (Horizontal > counterHorizontal && counterHorizontal <= -1)
            {
                counterHorizontal = Convert.ToInt32(sliderHorizontal.value);
                HorizontalIndikatorsMinus[counterHorizontal + 3].SetActive(false);
                HorizontalMachine.transform.rotation = Quaternion.Euler(0, 0, -sliderHorizontal.value);
            }

            if (Vertical > counterVertical && counterVertical >= 0)
            {
                counterVertical = Convert.ToInt32(sliderVertical.value);
                VerticalIndikatorsPlus[counterVertical - 1].SetActive(true);
                VerticalMachine.transform.rotation = Quaternion.Euler(0, 0, sliderVertical.value);
            }
            else if (Vertical < counterVertical && counterVertical >= 1)
            {
                counterVertical = Convert.ToInt32(sliderVertical.value);
                VerticalIndikatorsPlus[counterVertical].SetActive(false);
                VerticalMachine.transform.rotation = Quaternion.Euler(0, 0, sliderVertical.value);
            }

            if (Vertical < counterVertical)
            {
                counterVertical = Convert.ToInt32(sliderVertical.value);
                VerticalIndikatorsMinus[counterVertical + 4].SetActive(true);
                VerticalMachine.transform.rotation = Quaternion.Euler(0, 0, sliderVertical.value);
            }
            else if (Vertical > counterVertical && counterVertical <= -1)
            {
                counterVertical = Convert.ToInt32(sliderVertical.value);
                VerticalIndikatorsMinus[counterVertical + 3].SetActive(false);
                VerticalMachine.transform.rotation = Quaternion.Euler(0, 0, sliderVertical.value);
            }

            if (sliderHorizontal.value == 5 || sliderHorizontal.value == -5 || sliderVertical.value == -5 || sliderVertical.value == 5)
            {
                ChangePosition.SetActive(true);
            }
            else
            {
                ChangePosition.SetActive(false);
            }
        }
    }

    public void IndikatorsCounts()
    {
        HorizontalText.text = sliderHorizontal.value.ToString();
        VerticalText.text = sliderVertical.value.ToString();
    }

    public void AllIndicatorsOn()
    {  
        if (switchActive)
        {
            for (int i = 0; i < AllIndikators.Length; i++)
            {
            AllIndikators[i].SetActive(true);
            }
        }
    }

    public void AllIndicatorsOff()
    {
        if (switchActive)
        {
            sliderHorizontal.value = 0;
            sliderVertical.value = 0;
            for (int i = 0; i < AllIndikators.Length; i++)
            {
                AllIndikators[i].SetActive(false);
            }
        } 
    }

    public void CheckOn()
    {
        if (switchActive == false)
        {
            switchActive = true;
            SwitchOn.SetActive(true);
            SwitchOff.SetActive(false);
            sliderHorizontal.enabled = true;
            sliderVertical.enabled = true;

            sliderHorizontal.value = 0;
            sliderVertical.value = 0;
        }
        else
        {
            switchActive = false;
            SwitchOn.SetActive(false);
            SwitchOff.SetActive(true);
            sliderHorizontal.enabled = false;
            sliderVertical.enabled = false;
            ChangePosition.SetActive(false);

            sliderHorizontal.value = 0;
            sliderVertical.value = 0;
            HorizontalMachine.transform.rotation = Quaternion.Euler(0, 0, 0);
            VerticalMachine.transform.rotation = Quaternion.Euler(0, 0, 0);

            for (int i = 0; i < AllIndikators.Length; i++)
            {
                AllIndikators[i].SetActive(false);
            }
        }
    }
}
