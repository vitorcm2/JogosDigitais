using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    GameManager gm;
    Animator animator;
    public GameObject bullet;
    public Transform arma;
    private int lifes;

    public float shootDelay = 0.05f;
    private float _lastShootTimestamp = 0.0f;

    private void Start(){
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
        

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
        gm.vidas--;
        if (gm.vidas <= 0) Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        gm.ChangeState(GameManager.GameState.ENDGAME);

    }

    void FixedUpdate()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

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

   if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
       gm.ChangeState(GameManager.GameState.PAUSE);
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
