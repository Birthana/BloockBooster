using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBossShooting : MonoBehaviour
{
    //CoolDowns
    //[SerializeField] List<WaitTimes> listOfTimes;
    [SerializeField] List<ObjectPool> pool;
    [SerializeField] GameObject player;

    delegate float Attack();

    List<float> timers;

    List<Attack> listOfAttacks;
    // Start is called before the first frame update
    void Start()
    {
        //( foo ? bar : function() );
        timers = new List<float>();
        listOfAttacks = new List<Attack>();
        listOfAttacks.Add(SingleAttack);
        listOfAttacks.Add(StreamAttack);
        //listOfAttacks.Add(SpreadAttack);
        //listOfAttacks.Add(CircleAttack);
        foreach(Attack a in listOfAttacks )
        {
            timers.Add(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        float time = Time.deltaTime;
        for(int i = 0; i < listOfAttacks.Count; i++)
        {
            Debug.Log(timers[i]);
            if (timers[i] <= 0)
            {
                timers[i] = listOfAttacks[i]();
            }
            timers[i] -= time;
        }
    }

    float SingleAttack()
    {
        GameObject b = pool[0].FindUnusedObject();
        b.SetActive(true);
        b.transform.localPosition = Vector3.Normalize((player.transform.position - pool[0].transform.position));
        b.GetComponent<BulletMovement>().BossFire(player.transform.position);
        return 5.0f;
    }

    float StreamAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject b = pool[0].FindUnusedObject();
            b.SetActive(true);
            b.transform.localPosition = Vector3.Normalize((player.transform.position - pool[0].transform.position));
            b.GetComponent<BulletMovement>().BossFire(player.transform.position);
        }
        return 10.0f;
    }

    /*
    float SpreadAttack()
    {

    }

    float CircleAttack()
    {

    }*/
}
