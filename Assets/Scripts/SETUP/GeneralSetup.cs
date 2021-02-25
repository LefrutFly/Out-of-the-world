using UnityEngine;

[CreateAssetMenu(fileName = "GeneralSetup", menuName = "SETUP/GeneralSetup")]
public class GeneralSetup : ScriptableObject
{
    [SerializeField, Tooltip("�������� �� ��������� � ���� ����� � ����")]public bool drawLines = true;
    [Space]
    [SerializeField] public int LastOpenLevel;
    [SerializeField] public int LastUnlockedLevel;
}
