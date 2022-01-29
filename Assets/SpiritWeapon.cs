using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritWeapon : MonoBehaviour
{
    public Transform defaultTransform;
    public Transform pointTransform;
    public Collider damageCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            gameObject.transform.position = pointTransform.position;
            gameObject.transform.rotation = pointTransform.rotation;
            damageCollider.enabled = true; 
        }
        else
        {
            gameObject.transform.position = defaultTransform.position;
            gameObject.transform.rotation = defaultTransform.rotation;
            damageCollider.enabled = false;
        }
    }


}
