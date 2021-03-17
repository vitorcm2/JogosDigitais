using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : SteerableBehaviour, IDamageable
{
    private int vidas;

    private void Start(){
        
        vidas = 2;
    }


    public void TakeDamage()
    {
        vidas--;
        if (vidas <= 0) Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    
}