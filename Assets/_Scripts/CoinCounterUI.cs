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
    [SerializeField]  private  Ease  animationCurve;

    private float containerInitPositon;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPositon = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        // set the score to the masked text UI
        toUpdate.SetText($"{score}");
        // trigger the local move animation
        coinTextContainer.DOLocalMoveY(containerInitPositon + moveAmount, duration).SetEase(animationCurve);

        // start a coroutine to update the score
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score)
    {
        // this tells the editor to wait for a given period of time
        yield return new WaitForSeconds(duration);

        // we use duration since that's the same time as the animation
        current.SetText($"{score}"); // update the original score
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPositon, localPosition.z);
        // then reset the y-local position of the coinTextContainer
    }

}
