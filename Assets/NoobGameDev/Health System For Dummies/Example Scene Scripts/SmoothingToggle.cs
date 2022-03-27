using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothingToggle : MonoBehaviour
{
    [SerializeField] HealthSystemForDummies healthSystem;

    // Caches
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(onToggleChanged);
    }

    void Update()
    {
        toggle.isOn = healthSystem.HasAnimationWhenHealthChanges;
    }

    void onToggleChanged(bool value)
    {
        healthSystem.HasAnimationWhenHealthChanges = value;
    }
}
