using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    public GameObject coinParent = null;
    public Text counterTxt;
    public Image memoryImage = null;

    private Vector3[] coinPos;
    private Quaternion[] coinRotate;
    public int coinNum;
    public int coinTxt;


    private void Start()
    {
        coinNum = coinParent.transform.childCount;

        coinPos = new Vector3[coinNum];
        coinRotate = new Quaternion[coinNum];

        for (int i = 0; i < coinNum; i++)
        {
            coinPos[i] = coinParent.transform.GetChild(i).position;
            coinRotate[i] = coinParent.transform.GetChild(i).rotation;
        }

        EventManager.StartListening(ConstantManager.COIN_UI, ShowMemoryUI);
    }

    private void Reset()
    {
        for (int i = 0; i < coinNum; i++)
        {
            coinParent.transform.GetChild(i).position = coinPos[i];
            coinParent.transform.GetChild(i).rotation = coinRotate[i];
        }
    }

    public void ShowMemoryUI()
    {
        RewardCoinParent(coinNum);
    }

    public void RewardCoinParent(int noCoin)
    {
        Reset();

        var _delay = 0f;

        coinParent.SetActive(true);

        for (int i = 0; i < coinNum; i++)
        {
            coinParent.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(_delay)
                .SetEase(Ease.OutBack);

            coinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(760f, 448f), 0.8f).SetDelay(_delay + 0.5f)
                .SetEase(Ease.InBack);

            coinParent.transform.GetChild(i).DORotate(Vector3.zero, 0.7f).SetDelay(_delay + 0.7f)
                .SetEase(Ease.Flash).OnComplete(ImgeBig);

            coinParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(_delay + 1.8f)
                .SetEase(Ease.OutBack).OnComplete(CountCoinNum);

            _delay += 0.1f;
        }

        StartCoroutine(CountCoin(coinNum));
    }

    private void CountCoinNum()
    {

        coinTxt += 1;
        counterTxt.text = coinTxt.ToString();
    }

    private void ImgeBig()
    {
        memoryImage.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        memoryImage.transform.DOScale(new Vector3(1f, 1f, 1f), 0.05f);
    }

    private IEnumerator CountCoin(int _coinNum)
    {
        yield return new WaitForSecondsRealtime(0.8f);

        var _timer = 0f;

        for (int i = 0; i < _coinNum; i++)
        {


            _timer += 0.05f;

            yield return new WaitForSecondsRealtime(_timer);
        }
    }
}
