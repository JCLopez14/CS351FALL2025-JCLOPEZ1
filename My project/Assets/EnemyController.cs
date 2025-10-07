using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Update()
    {
        if (player != null)
        {
            // Move horizontally towards player
            float step = speed * Time.deltaTime;
            Vector2 newPos = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), step);
            transform.position = newPos;
        }
    }
}
