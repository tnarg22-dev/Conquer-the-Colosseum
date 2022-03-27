using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUIObjectWhenToggleOff : MonoBehaviour
{
    [SerializeField] string UIObjectName;

    // Caches

    new GameObject gameObject;
    Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find(UIObjectName);
        toggle = GetComponentInChildren<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(toggle.isOn);
    }
}
