using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3PlayerShoot : MonoBehaviour
{
    bool isShooting;

    BulletMovement Bmove;
    List<ObjectPool> objects;
    // Start is called before the first frame update
    void Start()
    {
        Bmove = GetComponent<BulletMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootBullets());
        }
    }

    IEnumerator ShootBullets()
    {
        isShooting = true;
        //Spawn Bullets form player
        foreach (ObjectPool p in objects)
        {
            GameObject b = p.FindUnusedObject();
            b.SetActive(true);
        }
        yield return new WaitForSeconds(0.05f);
        isShooting = false;
    }
}
