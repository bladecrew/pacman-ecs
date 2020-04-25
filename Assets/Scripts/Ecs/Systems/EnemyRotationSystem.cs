using Ecs.Components;
using Leopotam.Ecs;

namespace Ecs.Systems
{
  public class EnemyRotationSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent>.Exclude<PacmanComponent> _filter;
    
    public void Run()
    {
      foreach (var index in _filter)
      {
      }  
    }
  }
}