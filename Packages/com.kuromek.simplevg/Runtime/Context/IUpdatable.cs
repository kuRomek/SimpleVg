public interface IUpdatable
{
    public void Update(float deltaTime);
}

public interface ILateUpdatable
{
    public void LateUpdate(float deltaTime);
}