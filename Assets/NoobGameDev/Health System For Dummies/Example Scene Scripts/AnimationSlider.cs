using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSlider : MonoBehaviour
{
    [SerializeField] HealthSystemForDummies healthSystem;

    // Caches
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(onSliderChanged);
    }

    void Update()
    {
        slider.value = healthSystem.AnimationDuration;
    }

    void onSliderChanged(float value)
    {
        healthSystem.AnimationDuration = value;
    }
}
