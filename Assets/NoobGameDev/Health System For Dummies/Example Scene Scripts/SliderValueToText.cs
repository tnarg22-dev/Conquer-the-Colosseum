using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    [SerializeField] Slider slider;

    // Caches
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        double sliderValueRounded = System.Math.Round(slider.value, 2);
        text.text = $"{sliderValueRounded}s";
    }
}
