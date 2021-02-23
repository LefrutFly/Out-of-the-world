using System;
using UnityEngine;

public class DrawLines
{
    public static Action<GameObject, LineRenderer[], MonoBehaviour[]> OnDraw;
    public void Draw(GameObject gm, LineRenderer[] lines, MonoBehaviour[] ToObj)
    {
        Vector2 positionFirst = gm.transform.position;

        int index = 0;
        if (lines.Length >= ToObj.Length)
        {
            foreach (var positionSecond in ToObj)
            {
                lines[index].SetPosition(0, positionFirst);
                lines[index].SetPosition(1, positionSecond.transform.position);
                index++;
            }
        }
        else
        {
            Debug.LogError("Not enough lines, stoped in : " + index);
        }
    }
}