using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFilterSwitcher : MonoBehaviour
{
    public GameObject blurFilter;
    public GameObject depthMaskFilter;
    public GameObject edgeDetectionFilter;

    private void SwitchFilter(CameraFilterType filterType)
    {

        switch (filterType)
        {
            case CameraFilterType.DepthMask:
                blurFilter.SetActive(false);
                depthMaskFilter.SetActive(true);
                edgeDetectionFilter.SetActive(false);
                break;
            case CameraFilterType.EdgeDetection:
                depthMaskFilter.SetActive(false);
                edgeDetectionFilter.SetActive(true);
                break;
            case CameraFilterType.Blur:
                blurFilter.SetActive(true);
                depthMaskFilter.SetActive(false);
                edgeDetectionFilter.SetActive(false);
                break;
            default:
                blurFilter.SetActive(false);
                depthMaskFilter.SetActive(false);
                edgeDetectionFilter.SetActive(false);
                break;
        }
    }

    public void SwitchDimension()
    {
        if (!depthMaskFilter.activeSelf)
            SwitchFilter(CameraFilterType.DepthMask);
        else
            SwitchFilter(CameraFilterType.None);
    }
}

public enum CameraFilterType
{
    None = 0,
    Blur,
    DepthMask,
    EdgeDetection,
}
