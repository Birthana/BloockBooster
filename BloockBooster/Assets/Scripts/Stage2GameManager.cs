using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2GameManager : MonoBehaviour
{
    public int playerHealth;
    public float maxTimer;

    private float health;
    private float timer;

    private void Start()
    {
        health = playerHealth;
        timer = maxTimer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Timer End.");
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            Debug.Log("Player dies.");
        }
    }
}
