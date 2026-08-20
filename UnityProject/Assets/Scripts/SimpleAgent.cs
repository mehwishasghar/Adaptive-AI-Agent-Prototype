using UnityEngine;

public class SimpleAgent : MonoBehaviour
{
    public enum AILevel
    {
        Simple,
        Medium,
        Adaptive
    }

    [Header("AI Configuration")]
    public AILevel aiLevel = AILevel.Simple;

    public Transform target;
    public float moveSpeed = 3f;

    [Header("Decision Settings")]
    public float simpleDecisionInterval = 0.5f;
    public float mediumDecisionInterval = 0.2f;
    public float adaptiveDecisionInterval = 0.1f;

    [Header("Target Settings")]
    public float targetReachDistance = 1f;

    private float decisionTimer;
    private int decisionCount;

    private Vector3 currentDirection;
    private bool targetReached;

    void Start()
    {
        MakeDecision();
    }

    void Update()
    {
        if (target == null || targetReached)
            return;

        decisionTimer += Time.deltaTime;

        float decisionInterval = GetDecisionInterval();

        if (decisionTimer >= decisionInterval)
        {
            MakeDecision();
            decisionTimer = 0f;
        }

        transform.position +=
            currentDirection * moveSpeed * Time.deltaTime;

        CheckTarget();
    }

    float GetDecisionInterval()
    {
        switch (aiLevel)
        {
            case AILevel.Simple:
                return simpleDecisionInterval;

            case AILevel.Medium:
                return mediumDecisionInterval;

            case AILevel.Adaptive:

                float distance =
                    Vector3.Distance(
                        transform.position,
                        target.position
                    );

                // Far from target:
                // more frequent decisions
                if (distance > 5f)
                {
                    return 0.1f;
                }

                // Medium distance:
                if (distance > 2f)
                {
                    return 0.2f;
                }

                // Close to target:
                // fewer decisions
                return 0.5f;
        }

        return simpleDecisionInterval;
    }

    void MakeDecision()
    {
        decisionCount++;

        Vector3 direction =
            target.position - transform.position;

        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            currentDirection = direction.normalized;
        }
    }

    void CheckTarget()
    {
        float distance =
            Vector3.Distance(
                transform.position,
                target.position
            );

        if (distance <= targetReachDistance)
        {
            targetReached = true;
            currentDirection = Vector3.zero;

            Debug.Log(
                aiLevel + " AI reached the target."
            );
        }
    }

    public int GetDecisionCount()
    {
        return decisionCount;
    }

    public bool HasReachedTarget()
    {
        return targetReached;
    }
}