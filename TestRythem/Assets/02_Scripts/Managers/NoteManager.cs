using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    private double currentTime = 0d;

    [SerializeField] private Transform tfNoteAppear = null;
    [SerializeField] private GameObject goNote = null;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            GameObject _note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            _note.transform.SetParent(this.transform);
            TimingManager.Instance.boxNoteList.Add(_note);

            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            TimingManager.Instance.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
