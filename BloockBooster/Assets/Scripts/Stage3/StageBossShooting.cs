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
        listOfAttacks.Add(SpreadAttack);
        //listOfAttacks.Add(CircleAttack);
        foreach(Attack a in listOfAttacks )
        {
            timers.Add(1f);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        float time = Time.deltaTime;
        for(int i = 0; i < listOfAttacks.Count; i++)
        {
            
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
        return 1f;
    }

    float StreamAttack()
    {
        StartCoroutine(Stream());
        return 7f;
    }

    
    float SpreadAttack()
    {
        StartCoroutine(Spread());
        return 5f;
    }

    /*
    float CircleAttack()
    {

    }*/

    IEnumerator Stream()
    {
        List<BulletMovement> movement = new List<BulletMovement>();
        for (int i = 0; i < 5; i++)
        {
            GameObject b = pool[0].FindUnusedObject();
            b.SetActive(true);
            Vector3 randomArea = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
            b.transform.localPosition = Vector3.Normalize( ( (player.transform.position + randomArea) - (pool[0].transform.position) ) );
            b.GetComponent<BulletMovement>().BossFire(player.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Spread()
    {
        List<GameObject> movement = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject b = pool[0].FindUnusedObject();
            b.SetActive(true);
            b.transform.localPosition = new Vector3(0, 0, 0);
            movement.Add(b);
            yield return new WaitForSeconds(0.1f);
            
        }
        foreach (GameObject b in movement)
        {
            Vector3 randomArea = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0);
            b.transform.localPosition = Vector3.Normalize(((player.transform.position + randomArea) - (pool[0].transform.position)));
            b.GetComponent<BulletMovement>().BossFire(player.transform.position);
        }
    }

}
