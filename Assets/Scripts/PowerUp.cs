﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField] // 0 = triple shot, 1 = speed, 2 = shield
    private int powerupID;
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch(powerupID)
                {
                    case 0:
                        player.TripleShotActivate();
                        break;
                    case 1:
                        Debug.Log("Speed Collected");
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("Shields Collected");
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}