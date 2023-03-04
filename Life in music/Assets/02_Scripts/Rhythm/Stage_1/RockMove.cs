using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockMove : MonoBehaviour
{
    public enum Type
    {
        rock,
        fish,
    }

    public Type type;

    public AnimationCurve curve;

    public float duration = 1f;

    public float heightY = 3;

    [Space(50)]
    [Range(0, 1)]
    public float t;
    public Transform a;
    public Transform b;

    private void Start()
    {

    }

    private void Update()
    {
        //transform.localPosition = Vector3.Slerp(new Vector3(-50, 50, 0), new Vector3(0, 0, 0), duration);
        transform.position = Vector3.Slerp(a.position, b.position, t);
    }

    public IEnumerator Curve(Vector3 _start, Vector3 _target)
    {
        float _timePassed = 0f;

        Vector2 _end = _target;

        while (_timePassed < duration)
        {
            _timePassed += Time.deltaTime;

            float linearT = _timePassed / duration;
            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.localPosition = Vector2.Lerp(_start, _end, linearT) + new Vector2(0f, height);

            yield return null;
        }

    }
}
