using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 1;
    public Animator animator;
    public String triggerAttack = "Attack";
    public String triggerKill = "Death";
    public HealthBase healthBase;
    public AudioSource audioSource;
    public AudioSource audioSource2;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
        //Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }
    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
        PlayAudioDeathSound();
    }

    public void Damage(int damageAmount)
    {
        healthBase.Damage(damageAmount);
        PlayAudioDamageSound();
    }
    public void PlayAudioDamageSound()
    {
        audioSource.Play();
    }
    public void PlayAudioDeathSound()
    {
        audioSource2.Play();
    }
}
