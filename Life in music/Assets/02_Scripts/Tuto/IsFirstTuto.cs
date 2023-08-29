using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IsFirstTuto : MonoBehaviour
{
    private int tutoCnt;

    [Space(30)]
    public List<GameObject> tutoObj = new List<GameObject>();
    public AudioSource mySource = null;
    public AudioClip myClip = null;

    [Space(20)]
    public CurrnetstageSO currentSO = null;

    [Space(20)]
    public Text tutoText;
    private int tutoNum = 0;
    private GameObject currentTutoObj = null;

    [Space(20)]
    public AudioSource typingAudio = null;
    private float currentSpeed = 0f;

    [Space(20)]
    public float defaultSpeed = 0.08f;
    public float fastSpeed = 0.03f;

    private bool isTyping = false;
    public bool isShellTuto = false;
    public Button backButton = null;

    [Space(20)]
    public List<string> firstTutoText = new List<string>();

    public TextMeshProUGUI testText;

    private void Start()
    {
        if (currentSO == null)
        {
            Debug.LogError("CurrentSo is NULL");
        }

        tutoCnt = tutoObj.Count + 1;
        OnClickTutoNext();
    }

    public void OnClickTutoNext()
    {
        if (isTyping)
        {
            return;
        }

        CheckNum(true);
    }

    public void OnClickTutoBack()
    {
        CheckNum(false);
    }

    private void Update()
    {

        if (isTyping)
        {
            currentSpeed = fastSpeed;
            typingAudio.pitch = 1.3f;
        }
    }

    private void Tuto()
    {
        switch (tutoNum)
        {
            case 1:
                CheckCurrentGameObj(tutoObj[0], firstTutoText[0], 3);

                backButton.gameObject.SetActive(false);
                break;

            case 2:
                CheckCurrentGameObj(tutoObj[1], firstTutoText[1], 1);

                backButton.gameObject.SetActive(true);
                break;

            case 3:
                CheckCurrentGameObj(tutoObj[2], firstTutoText[2], 0);
                break;

            case 4:
                isShellTuto = true;
                CheckCurrentGameObj(tutoObj[3], firstTutoText[3], 2);
                break;

            case 5:
                CheckCurrentGameObj(tutoObj[4], firstTutoText[4], 0);
                break;

            case 6:
                CheckCurrentGameObj(tutoObj[5], firstTutoText[5], 7);
                break;

            case 7:
                currentSO.stageName = DefineManager.StageNames.Sea_01;
                PlayerPrefs.SetInt("Stage01Check", 1);

                SceneManager.LoadScene("Stage_01");
                break;
        }

        Debug.Log(tutoNum);
    }

    private void CheckNum(bool _isPlus)
    {
        if (_isPlus)
        {
            var _input = tutoNum + 1;

            if (_input <= tutoCnt)
            {
                tutoNum++;
            }
        }
        else
        {
            var _iiput = tutoNum - 1;

            if (_iiput > 0)
            {
                tutoNum--;
            }
        }

        Tuto();
    }

    private void CheckCurrentGameObj(GameObject _obj, string _input, int _index)
    {
        if (isTyping)
        {
            return;
        }
        string _text = _input;

        StartCoroutine(TextOutCor(_text, _index));

        mySource.PlayOneShot(myClip);
    }



    private IEnumerator TextOutCor(string _input, int _index)
    {
        tutoText.text = _input;
        typingAudio.pitch = 1f;
        isTyping = true;
        typingAudio.Play();

        currentSpeed = defaultSpeed;

        for (int i = 0; i < _input.Length; i++)
        {

            testText.text = _input.Substring(0, i + 1);

            yield return new WaitForSeconds(currentSpeed);
        }

        typingAudio.Stop();
        isTyping = false;   
        testText.SetText(_input + $" <sprite={_index}>");
    }
}
