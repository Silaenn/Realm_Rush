using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField]
    ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosetTarget();
        AimWeapon();
    }

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);

            transform.LookAt(target);

            if (targetDistance < range)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
    }

    void Attack(bool isActive)
    {
        var emmisionModule = projectileParticles.emission;
        emmisionModule.enabled = isActive;
    }
}
