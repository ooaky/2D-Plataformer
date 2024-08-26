using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.05f;
    public float jumpScaleX = 1.0f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolDeath = "Death";
    public float playerSwipeDuration = .1f;

    [Header("DamageColor")]
    public Color color = Color.red;
}
