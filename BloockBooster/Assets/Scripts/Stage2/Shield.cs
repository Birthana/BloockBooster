﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform position;
    public float speed;
    [SerializeField] private Vector3 player;

    private void Start()
    {
        position = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 zAxis = new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            position.RotateAround(player, zAxis, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            position.RotateAround(player, zAxis, -speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            position.RotateAround(player, zAxis, 180);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Stage2Bullet>())
        {
            Destroy(collision.gameObject);
        }
    }
}