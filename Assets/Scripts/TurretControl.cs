using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretControl : MonoBehaviour
{
    [SerializeField] int firerate;
    [SerializeField] int Hp;
    [SerializeField] GameObject Target;
    [SerializeField] float FireRange;
    [SerializeField] float NextShootTimer;


    protected virtual void Start()
    {
        NextShootTimer = 0f;
    }

    protected virtual void Update()
    {
        if (Target == null) return;

        RotateToTarget();

        NextShootTimer -= Time.deltaTime;
        if (NextShootTimer <= 0f && IsInRange())
        {
            Fire();
            NextShootTimer = 1f / firerate;
        }
    }

    protected bool IsInRange()
    {
        return Vector3.Distance(transform.position, Target.transform.position) <= FireRange;
    }

    protected void RotateToTarget()
    {
        Vector3 direction = Target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected abstract void Fire();



}
