using UnityEngine;

[CreateAssetMenu(fileName = "KeyCodes", menuName = "System/KeyCodes")]
public class KeyCodesSO : ScriptableObject
{
    [SerializeField] public KeyCode Use;
}
