﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void Start()
    {
        //SoundManager.instance.PlayBackground(4);
        UIManager.instance.SetMaxHealth(7);
        UIManager.instance.SetTimer(60,5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Hole"))
        {
            Debug.Log("Abyss to my heart");
            UIManager.instance.TakeDamage();
        }
    }
}
