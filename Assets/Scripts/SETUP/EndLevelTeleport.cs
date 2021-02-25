using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevelTeleport : Interacts<PlayerBehaviour>
{
    [SerializeField, Tooltip("[SETUP]")] private Level level;
    [SerializeField] private GeneralSetup generalSetup;

    protected override void DoThisAction()
    {
        int nextLevel = level.LevelInxdex + 1;
        if(nextLevel > generalSetup.LastUnlockedLevel)
        {
            generalSetup.LastUnlockedLevel = nextLevel;
            Saving.Save(generalSetup);
        }
        SceneManager.LoadScene("Level_" + nextLevel);
    }
}
