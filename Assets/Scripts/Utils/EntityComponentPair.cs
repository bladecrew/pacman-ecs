using Leopotam.Ecs;

namespace Utils
{
  public class EntityComponentPair<T> 
    where T : struct
  {
    public EcsEntity Entity;
    public T Component;
  }
}