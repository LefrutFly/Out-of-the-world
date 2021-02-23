using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevelTeleport : Interacts<PlayerBehaviour>
{
    [SerializeField, Tooltip("[SETUP]")] private Level level;

    protected override void DoThisAction()
    {
        int nextLevel = level.LevelInxdex + 1;
        SceneManager.LoadScene("Level_" + nextLevel);
    }
}
