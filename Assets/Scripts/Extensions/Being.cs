using UnityEngine;

public abstract class Being : MonoBehaviour
{
    [SerializeField] public DataHP hp = new DataHP();
    [SerializeField] public DataSpeed Speed = new DataSpeed();
    [SerializeField] public GameObject view;

    private void Awake()
    {
        hp.death.OnInitDeath += () =>
        {
            InitDeath();
        };
        AwakeBehaviour();
    }

    private void FixedUpdate()
    {
        FixedUpdateBehaviour();
    }

    private void Update()
    {
        UpdateBehaviour();
    }

    protected virtual void UpdateBehaviour() { }
    protected virtual void FixedUpdateBehaviour() { }
    protected virtual void AwakeBehaviour() { }
    protected abstract void InitDeath();
}
