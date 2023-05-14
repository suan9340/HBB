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

    private void Start()
    {
        if (boardZoomAnim == null)
        {
            Debug.LogWarning("BoardZoomAnim is NULL!!!!!!!");
        }
    }
    public void OnClickCheckStage(int num)
    {
        Debug.Log("SceneLoad");
        SceneManager.LoadScene(num);
    }

    public void OnClickBoardZoom()
    {

    }

    private void OnMouseDown()
    {
        if (isBoardZoom) return;

        boardCol.enabled = false;
        isBoardZoom = true;

        boardZoomAnim.SetTrigger("isBoardZoomIn");
    }

}
