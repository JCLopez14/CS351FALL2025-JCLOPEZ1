using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFlyingPatrolChase : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float speed = 2f;
    public float chaseRange = 3f;

    public enum EnemyState { Patrolling, Chasing }
    public EnemyState currentState = EnemyState.Patrolling;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int currentPatrolPointIndex = 0;

    private Vector2[] patrolWorldPos;

    void Start()
    {
        GameObject pObj = GameObject.FindWithTag("Player");
        if (pObj != null) player = pObj.transform;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("No patrol points assigned!");
            enabled = false;
            return;
        }

        // LOCK their world positions so they don’t “move with the prefab”
        patrolWorldPos = new Vector2[patrolPoints.Length];
        for (int i = 0; i < patrolPoints.Length; i++)
            patrolWorldPos[i] = patrolPoints[i].position;
    }

    void Update()
    {
        UpdateState();

        if (currentState == EnemyState.Patrolling) Patrol();
        else ChasePlayer();
    }

    void UpdateState()
    {
        if (player == null)
        {
            currentState = EnemyState.Patrolling;
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        currentState = (distance <= chaseRange) ? EnemyState.Chasing : EnemyState.Patrolling;
    }

    void Patrol()
    {
        Vector2 targetPos = patrolWorldPos[currentPatrolPointIndex];

        if (Vector2.Distance(transform.position, targetPos) <= 0.5f)
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolWorldPos.Length;

        MoveTowardsPosition(patrolWorldPos[currentPatrolPointIndex]);
    }

    void ChasePlayer()
    {
        if (player == null) { rb.velocity = Vector2.zero; return; }
        MoveTowardsPosition(player.position);
    }

    void MoveTowardsPosition(Vector2 targetPos)
    {
        Vector2 direction = targetPos - (Vector2)transform.position;
        direction.Normalize();

        rb.velocity = direction * speed;

        if (direction.x < 0) sr.flipX = false;
        else if (direction.x > 0) sr.flipX = true;
    }
}
