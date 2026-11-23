public interface IUpdatable
{
    public void Update(float deltaTime);
}

public interface ILateUpdatable
{
    public void LateUpdate(float deltaTime);
}

public interface IFixedUpdatable
{
    public void FixedUpdate(float deltaTime);
}