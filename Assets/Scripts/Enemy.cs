using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Enemy Way")]
    public Transform[] pointsOfPath;
    public int currentPoint;
    [Header("Enemy Move")]
    public float speedEnemy;
    public float lastPositionX;
    
    void Start()
    {
        
    }

    void Update()
    {
        EnemyMove();
        MirrorEnemy();
    }

    private void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsOfPath[currentPoint].position, speedEnemy * Time.deltaTime);

        if(transform.position == pointsOfPath[currentPoint].position) {
            currentPoint++;
            lastPositionX = transform.localPosition.x;
            if(currentPoint >= pointsOfPath.Length) {
                currentPoint = 0;
            }
        }
    }

    private void MirrorEnemy()
    {
        if(transform.localPosition.x < lastPositionX) {
            GetComponent<SpriteRenderer>().flipX = false; 
        }
        else {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
