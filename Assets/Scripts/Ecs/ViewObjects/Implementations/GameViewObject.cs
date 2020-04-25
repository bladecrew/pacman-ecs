using Ecs.Components;
using Leopotam.Ecs;

namespace Ecs.ViewObjects.Implementations
{
  public class GameViewObject : ViewObject
  {
    protected override void Inject(EcsWorld world)
    {
      var entity = world.NewEntity();
      ref var component = ref entity.Set<GameComponent>();
    }
  }
}