using System.Collections;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;

    private float containerInitPositon;
    private float moveAmount;

    private void Start()
    {
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPositon = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
        Debug.Log(moveAmount);
        Debug.Log(containerInitPositon);
    }

    public void UpdateScore(int score)
    {
        // set the score to the masked text UI
        toUpdate.SetText($"{score}");
        // trigger the local move animation
        coinTextContainer.DOLocalMoveY(173, duration); // hardcoded value
    }

}
