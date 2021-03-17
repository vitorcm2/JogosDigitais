using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject tiro;
    private int vidas;

    private void Start(){
        
        vidas = 3;
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        vidas--;
        if (vidas <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    
}
