using UnityEngine;
using UnityEditor;

public class GameUtility
{
    [MenuItem("GameUtility/Clear All SaveData")]
    static void ClearAllSaveData()
    {
        if (EditorUtility.DisplayDialog("���� ���̺� ���� ����",
            "���� ���� �Ͻðڽ��ϱ�?", "��", "�ƴϿ�"))
        {
            Debug.Log("���� �Ϸ�");
            PlayerPrefs.DeleteAll();
        }
    }
}