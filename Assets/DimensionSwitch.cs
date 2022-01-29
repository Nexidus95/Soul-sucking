using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DimensionSwitch : MonoBehaviour
{
    public UnityEvent dimensionSwitchEvent;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dimensionSwitchEvent.Invoke();
        }
    }
}
