using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    
    EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();    
    }

    public void TakeDamage(float damage)
    {
        enemyAI.GetRabbitAnimator().SetTrigger("Damage");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
            //Destroy(gameObject);
        }
    }

    private void Die()
    {
        enemyAI.SetIsProvoked(false);
        enemyAI.GetRabbitAnimator().SetTrigger("Death");
    }

    public float GetHP()
    {
        return hitPoints;
    }
}
