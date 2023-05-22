using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardController : MonoBehaviour
{
    public Animator boardZoomAnim = null;
    private bool isBoardZoom = false;

    [Space(20)]
    [Header("Colliders")]
    public List<BoxCollider2D> picCol = new List<BoxCollider2D>();
    public BoxCollider2D boardCol = null;

    private bool isMoving = false;

    private void Start()
    {
        if (boardZoomAnim == null)
        {
            Debug.LogWarning("BoardZoomAnim is NULL!!!!!!!");
        }
    }
    public void OnClickCheckStage(int num)
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;



        Debug.Log("SceneLoad");
        SceneManager.LoadScene(num);
    }

    public void OnClickBoardZoom()
    {

    }

    private void OnMouseDown()
    {
        if (isMoving)
            return;

        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking /*|| isBoardZoom*/)
            return;

        isMoving = true;

        if (isBoardZoom)
        {
            isBoardZoom = false;
            boardZoomAnim.SetTrigger("isBoardZoomOut");
        }
        else
        {
            //boardCol.enabled = false;
            isBoardZoom = true;

            boardZoomAnim.SetTrigger("isBoardZoomIn");
        }

        Invoke(nameof(MovingSet), 1f);
    }

    private void MovingSet()
    {
        isMoving = false;
    }
}
