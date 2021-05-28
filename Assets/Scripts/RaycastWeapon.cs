using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{    
    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    float damage = 30f;

    Ray ray;
    RaycastHit hitInfo;
    public void StartFiring()
    {
        isFiring = true;
        foreach (var particle in muzzleFlash)
        {
            particle.Emit(1);
        }

        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if (Physics.Raycast(ray, out hitInfo))
        {
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;

            EnemyHealth targetHP = hitInfo.transform.GetComponent<EnemyHealth>();            
            if (targetHP == null)//if you shoot a non-enemy
            {
                return;
            }
            targetHP.TakeDamage(damage);
            EnemyAI targetAI = hitInfo.transform.GetComponent<EnemyAI>();
            if (targetHP.GetHP() > 0)
            {
                targetAI.SetIsProvoked(true);
            }
        }
        else
        {
            return;
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
