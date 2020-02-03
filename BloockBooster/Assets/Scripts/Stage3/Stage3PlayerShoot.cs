using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3PlayerShoot : MonoBehaviour
{
    bool isShooting = false;
    BulletMovement Bmove;
    [SerializeField]List<ObjectPool> objects;
    // Start is called before the first frame update
    void Start()
    {
        Bmove = GetComponent<BulletMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Shoot();
        }
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
        //Spawn Bullets form player
        isShooting = true;
        foreach (ObjectPool p in objects)
        {
            GameObject b = p.FindUnusedObject();
            b.SetActive(true);
            b.transform.localPosition = p.gameObject.transform.localPosition + (p.gameObject.transform.up * 0.01f);
            b.GetComponent<BulletMovement>().MouseFire(p.transform.localPosition);
        }
        yield return new WaitForSeconds(0.05f);
        isShooting = false;
    }
}
