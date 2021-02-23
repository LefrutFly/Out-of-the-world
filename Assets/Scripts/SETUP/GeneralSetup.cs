using UnityEngine;

[CreateAssetMenu(fileName = "GeneralSetup", menuName = "SETUP/GeneralSetup")]
public class GeneralSetup : ScriptableObject
{
    [SerializeField, Tooltip("включать ли подсказки в виде линий в игре")]public bool drawLines = true;
}
