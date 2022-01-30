using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Soul : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 30;
    public int reviveTimeSec = 5;

    int currentHealth;
    bool gettingSucked = false;
    int damageDealtPerIncrement = 0;
    int reviveProgress = 0;

    public UnityEvent deathEvent;
    public UnityEvent reviveEvent;

    void Start()
    {
        currentHealth = health;
        deathEvent.AddListener(OnDeath);
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            deathEvent.Invoke();
        }

        StartCoroutine(Revive());
    }

    private void OnDisable()
    {
        StopCoroutine(Revive());
        StopCoroutine(DecrementHealth());
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.tag == "SoulCollider")
        {
            damageDealtPerIncrement = other.GetComponent<DamageTrigger>().damage;
            StartCoroutine(DecrementHealth());

            //Subscribe the health system to the death event
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "SoulCollider")
        {
            damageDealtPerIncrement = 0;
            gettingSucked = false;
            currentHealth = health;
            StopCoroutine(DecrementHealth());
        }
    }

    IEnumerator DecrementHealth()
    {

        while(gettingSucked)
        {
            currentHealth -= damageDealtPerIncrement;
            yield return new WaitForSeconds(.2f);
        };  

        while(currentHealth < health)
        {
            currentHealth = +damageDealtPerIncrement;
            yield return new WaitForSeconds(.2f);
        }
            

        damageDealtPerIncrement = 0;
    }

    IEnumerator Revive()
    {
        while(reviveProgress < reviveTimeSec)
        {
            if(!gettingSucked)
                reviveProgress++;

            yield return new WaitForSeconds(1);
        }

        reviveEvent.Invoke();
        Destroy(this);
    }

    void OnDeath()
    {
        Destroy(this);
    }
}
