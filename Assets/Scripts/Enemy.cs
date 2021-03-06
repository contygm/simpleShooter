﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public int damage;
    public Transform targetTransform; // player's transform

    void FixedUpdate () {
        if(targetTransform != null) {
            // NOTE: use MoveTowards to move at constant speed
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void Attack(Player player) {
        player.health -= this.damage;
        Destroy(this.gameObject);
    }
}
