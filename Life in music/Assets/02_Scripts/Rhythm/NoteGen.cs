using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGen : MonoSingleTon<NoteGen>
{
    // todo 나중에 스크립터블 오브젝트로 옮길 코드
    public DefineManager.Stage_01_MoveType moveType;

    private IGen igen = new ShellGen();
    private void Start()
    {
        EventManager<List<bool>>.StartListening(ConstantManager.BEAT, Gen);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Gen(new List<bool> { true });
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Gen(new List<bool> { false, true });
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    Gen(new List<bool> { false, false, true });
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    Gen(new List<bool> { false, false, false, true });
        //}
    }

    private void Gen(List<bool> list)
    {
        igen.Gen(list);
    }

  public void IgenRock()
    {
        igen = new RockGen();
    }
}
