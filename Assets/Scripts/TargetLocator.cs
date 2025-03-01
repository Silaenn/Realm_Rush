using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        if (target != null)
        {

            transform.LookAt(target.position);
        }
    }
}
