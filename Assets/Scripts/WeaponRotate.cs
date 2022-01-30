using UnityEngine;
using System.Collections;

public class WeaponRotate : MonoBehaviour
{

    private float desiredRot;
    public float rotSpeed = 100;
    public float damping = 10;

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.z;
    }

    private void OnLevelWasLoaded(int level)
    {
        desiredRot = transform.eulerAngles.z;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2) desiredRot -= rotSpeed * Time.deltaTime;
            else desiredRot += rotSpeed * Time.deltaTime;
        }

        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}