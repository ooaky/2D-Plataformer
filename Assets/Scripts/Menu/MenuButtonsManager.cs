using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;
    [Header("Animation")]
    public float animationDuration = 0.2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;
    
    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }
    
    private void HideAllButtons()
    {
        foreach(var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }
    private void ShowButtons()
    {
        for(int i =0; i< buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, animationDuration).SetDelay(i*delay).SetEase(ease);
        }
    }
}
