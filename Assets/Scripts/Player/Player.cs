
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public HealthBase healthBase;
    public Animator animator;
    public ParticleSystem dust;

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

    [Header("Jump Setup")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround;
    public ParticleSystem jumpVFX;
    public AudioSource audioJump;

    private float _currentSpeed;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround * spaceToGround);
    }
    private void Update()
    {
        IsGrounded();
        HandleJump();
        HandleMoviment();
        HandleRun();
    }
    private void PlayJumpSound()
    {
        audioJump.Play();
    }

    private void HandleMoviment()
    {

        if (Input.GetKey(KeyCode.A))
        {
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != -1)
            {
                myRigibody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
            CreateDust();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != 1)
            {
                myRigibody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
            CreateDust();
        }
        else
            animator.SetBool(sOPlayerSetup.boolRun, false);

        if (myRigibody.velocity.x > 0)
            myRigibody.velocity += sOPlayerSetup.friction;
        else
            myRigibody.velocity -= sOPlayerSetup.friction;
    }


    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigibody.velocity = Vector2.up * sOPlayerSetup.forceJump;
            myRigibody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigibody.transform);
            PlayJumpSound();
            PlayJumpVFX();
            HandleScaleJump();
            CreateDust();


        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVfxByType(VFXManager.VFXType.JUMP, transform.position);
        if (jumpVFX != null) jumpVFX.Play();
    }
    private void HandleScaleJump()
    {
        myRigibody.transform.DOScaleY(sOPlayerSetup.jumpScaleY, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
        myRigibody.transform.DOScaleX(sOPlayerSetup.jumpScaleX, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
    }
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(sOPlayerSetup.boolDeath);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    private void HandleRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = sOPlayerSetup.speedRun;
            VFXManager.Instance.PlayVfxByType(VFXManager.VFXType.RUN, transform.position);
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
        }

    }
    void CreateDust()
    {
        dust.Play();
    }
}