public interface IState
{
    void EnterState();
    void UpdateState();
    void ExitState();
    void OnEnable();
    void OnDisable();
}