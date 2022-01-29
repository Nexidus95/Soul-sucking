using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{
    public GameObject TheSpider;
    public int EnemyHealth = 20;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (EnemyHealth <= 0)
        {
            this.GetComponent<SpiderFollow>().enabled = false;
            StartCoroutine(SpiderDeath());
        }*/
    }

    IEnumerator SpiderDeath()
    {
        TheSpider.GetComponent<Animation>().Play("die");
        yield return new WaitForSeconds(3);
        //Destroy(gameObject);
    }

}
