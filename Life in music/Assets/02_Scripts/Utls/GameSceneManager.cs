using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    public enum Scene
    {
        Menu,
        Room,

        FirstTuto,

        Stage_01,
        Stage_02,
        Stage_03,
        Stage_04,

        StageEnd,
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

}
