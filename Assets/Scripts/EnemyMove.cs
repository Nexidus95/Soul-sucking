using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TheEnemy;
    public float EnemySpeed;
    /*public float TheDistance = PlayerCasting.DistanceFromTarget;*/
    public int MoveTrigger;
    

    void Update()
    {
/*        TheDistance = PlayerCasting.DistanceFromTarget;

        if (TheDistance <= 10)
        {
            EnemySpeed = 1.0f;
            float dt = EnemySpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, dt);

        }*/
    }




}
