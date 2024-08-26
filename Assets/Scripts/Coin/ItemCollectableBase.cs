using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";
    public ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        gameObject.SetActive(false);
    }


    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
        if (audioSource != null)
        {
            audioSource.transform.parent = null;
            audioSource.Play();
            Destroy(audioSource.gameObject, 3f);
        }
        
        
    }
}