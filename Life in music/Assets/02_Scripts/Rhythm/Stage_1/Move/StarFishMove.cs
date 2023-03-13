using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFishMove : MonoBehaviour
{
    private static GameObject mom;
    public static float _spos = -220f;

    public static bool isFirst = true;

    public static void StarFishAdd ()
    {
        _spos += 20;
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Starfish)(Clone)");
        }

        var _obj = Resources.Load<StarFishMove>("Notes/Stage_01/StarfishNote");

        _spos += 20;

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
            _inst.transform.localPosition = new Vector3(500f, _spos, 0f);
        }
        else
        {
            Debug.LogError("ShellfishNote NULL");
        }
    }

    public static void Remove()
    {
        // 자동삭제
    }

    [Header("NoteAnimation")]
    public Animator starfish_noteAnimation = null;

    private RectTransform rect;



    private void Start()
    {
        rect = GetComponent<RectTransform>();
        starfish_noteAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveStarFish();
    }

    private void MoveStarFish()
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            isFirst = false;
        }
    }

    public void ShellfishDown()
    {
      //  starfish_noteAnimation.SetTrigger("isDown");
    }
}
