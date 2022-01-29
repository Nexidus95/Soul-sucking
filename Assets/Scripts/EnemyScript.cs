using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject TheZombie;
    public int EnemyHealth = 15;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (EnemyHealth <= 0)
        {
            this.GetComponent<ZombieFollow>().enabled = false;
            StartCoroutine(ZombieDeath());
        }*/
    }

    IEnumerator ZombieDeath()
    {
        TheZombie.GetComponent<Animation>().Play("Dying");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
