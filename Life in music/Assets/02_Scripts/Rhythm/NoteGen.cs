using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteGen : MonoSingleTon<NoteGen>
{
    // todo 나중에 스크립터블 오브젝트로 옮길 코드
    public DefineManager.Stage_01_MoveType moveType;

    public IGen igen;
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

    public void IgenShell()
    {
        igen = new ShellGen();
    }

    public void IgenRock()
    {
        igen = new RockGen();
    }

    public void IgenSeaweed()
    {
        igen = new SeaWeedGen();
    }

    public void IgenConch()
    {
        igen = new ConchGen();
    }

    public void IGenStarFish()
    {
        igen = new StarFishGen();
    }

    public void IGenBell()
    {
        igen = new BellGen();
    }

    public void IGenWater()
    {
        igen = new BalloonGen();
    }

    public void IGenBook()
    {
        igen = new BookGen();
    }

    public void IGenUmbrella()
    {
        igen = new UmbrellaGen();
    }

    public void IGenBroomStick()
    {
        igen = new BroomStickGen();
    }

}
