using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GeneralSetup generalSetup;
    [Space]
    [SerializeField] public int LevelInxdex;

    private bool drawLines
    {
        set
        {
            if (value == true)
            {
                DrawLines.OnDraw = (gm, lines, ToObj) =>
                {
                    DrawLines draw = new DrawLines();
                    draw.Draw(gm, lines, ToObj);
                };
            }
            else
            {
                DrawLines.OnDraw = (gm, lines, ToObj) => { };
            }
        }
    }

    private void Awake()
    {
        drawLines = generalSetup.drawLines;
        generalSetup.LastOpenLevel = LevelInxdex;
        Saving.Save(generalSetup);
    }
}
