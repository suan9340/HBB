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

        SettingPicture(false);
    }

    public void OnClickCheckStage(int num)
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;

        Debug.Log("SceneLoad");
        SceneManager.LoadScene(num);
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
            SettingPicture(false);

            isBoardZoom = false;
            boardZoomAnim.SetTrigger("isBoardZoomOut");
        }
        else
        {
            SettingPicture(true);

            isBoardZoom = true;
            boardZoomAnim.SetTrigger("isBoardZoomIn");
        }

        Invoke(nameof(MovingSet), 1f);
    }

    private void MovingSet()
    {
        isMoving = false;
    }

    private void SettingPicture(bool _bolen)
    {
        if (picCol[0] == null || picCol[1] == null)
        {
            Debug.LogError("picCol is NULL!!");
            return;
        }

        picCol[0].enabled = _bolen;
        picCol[1].enabled = _bolen;
    }
}
