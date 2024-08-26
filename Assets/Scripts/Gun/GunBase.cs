using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;
    public Transform positionToShoot;
    public Transform playerSideReference;
    public float timeBetweenShoot = .1f;
    private Coroutine _currentCorroutine;
    public ParticleSystem shootVFX;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _currentCorroutine = StartCoroutine(StartShoot());

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_currentCorroutine != null)
                StopCoroutine(_currentCorroutine);
        }
    }

    private void PlayShootVFX()
    {
        if (shootVFX != null) shootVFX.Play();
    }
    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            PlayShootVFX();
            PlayShootAudio();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void PlayShootAudio()
    {
        shootSound.Play();
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
