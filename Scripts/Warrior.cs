using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Warrior : MonoBehaviour
{
    private static List<Warrior> warriorList = new List<Warrior>();

    private static Warrior GetClosest(bool targetEnemy, Vector3 position)
    {
        Warrior closest = null;
        foreach(Warrior warrior in warriorList)
        {
            if(warrior.isEnemy == targetEnemy)
            {
                if(closest == null)
                {
                    closest = warrior;
                }
                else
                {
                    if(Vector3.Distance(warrior.GetPosition(), position) < Vector3.Distance(closest.GetPosition(), position))
                    {
                        closest = warrior;
                    }
                }
            }
        }

        return closest;
    }

    [SerializeField] private bool isEnemy;
    private Vector3 targetPosition;
    private State state;

    private enum State
    {
        Normal,
        Busy
    }

    private void Start()
    {
        warriorList.Add(this);
        state = State.Normal;   
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                HandleAttacks();
                break;

            case State.Busy:
                break;
        }
    }
    private void HandleAttacks()
    {
        Warrior targetWarrior = GetClosest(!isEnemy, GetPosition());
        if(targetWarrior != null)
        {
            SetTargetPosition(targetWarrior.GetPosition());
            if (Vector3.Distance(GetPosition(), targetWarrior.GetPosition()) < 20f)
            {
                // Attack
                state = State.Busy;
                Vector3 attackDir = (targetWarrior.GetPosition() - GetPosition()).normalized;
            }
        }
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        targetPosition.z = 0f;
        this.targetPosition = targetPosition;
    }

}
