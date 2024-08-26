using System.Collections;
using System.Collections.Generic;
using Core.Singleton;
using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;
    private GameObject _currentPlayer;


    [Header("Animation")]
    public float animationDuration = 0.2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(player);
        _currentPlayer.transform.position = startPoint.position;
        _currentPlayer.transform.DOScale(0,animationDuration).SetEase(ease).From();
    }

}
