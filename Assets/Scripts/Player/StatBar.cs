using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(float sValue)
    {
        slider.maxValue = sValue;
        slider.value = sValue;

        fill.color = gradient.Evaluate(1f);

    
    }

    public void SetValue(float sValue)
    {
        slider.value = sValue;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
