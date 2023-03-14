using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StarFishMove : MonoBehaviour
{
    private static GameObject mom;
    public static float _spos = -220f;

    public static bool Starfish_isFirst = true;

    public static void StarFishAdd()
    {
        _spos += 20;
        

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

    private void OnEnable()
    {
        
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
       AddList(gameObject);
    }

    private void AddList(GameObject _obj)
    {
        UIManager.Instance.RhythmNoteEffect();

        if (Starfish_isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            Starfish_isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.STARFISH_ADD, _obj);
    }

    public void StarfishDown()
    {
        starfish_noteAnimation.SetTrigger("isStarfishClick");
    }
}
