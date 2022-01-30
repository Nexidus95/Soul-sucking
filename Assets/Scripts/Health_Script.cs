using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Script : MonoBehaviour
{
    [SerializeField] private Image heart0;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
    [SerializeField] private Image heart4;

    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 100f)
        {
            heart0.enabled = true;
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
            heart4.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            health -= 20f;
        }
        if (health <= 80f)
        {
            heart4.enabled = false;
        }
        if (health <= 60f)
        {
            heart3.enabled = false;
        }
        if (health <= 40f)
        {
            heart2.enabled = false;
        }
        if (health <= 20f)
        {
            heart1.enabled = false;
        }
        if (health <= 0f)
        {
            Debug.Log("Game Over!");
            heart0.enabled = false;
        }
    }
}
