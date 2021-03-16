using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    public Transform arma;
    private int lifes;

    public float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;

    private void Start(){
        animator = GetComponent<Animator>();
        lifes = 10;

    }


    public AudioClip shootSFX;

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if (yInput != 0 || xInput != 0 ){
            animator.SetFloat("Velocity", 1.0f);
        } else {
            animator.SetFloat("Velocity", 0.0f);
        }

        if(Input.GetAxisRaw("Jump") != 0) //Fire1 = Ctrl
        {
           Shoot();
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
{

    

    if (collision.CompareTag("Inimigos"))
    {
        Destroy(collision.gameObject);
        TakeDamage();
    }
}


    
}
