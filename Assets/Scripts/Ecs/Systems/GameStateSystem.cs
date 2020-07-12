using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;

namespace Ecs.Systems
{
  public class GameStateSystem : IEcsRunSystem
  {
    private EcsWorld _world;

    private EcsFilter<PacmanComponent> _pacmanFilter;
    private EcsFilter<CoinComponent> _coinFilter;

    public void Run()
    {
      var currentState = GameState.Play;

      var pacman = _pacmanFilter.First().Component;

      if (pacman.Health <= 0)
        currentState = GameState.Dead;
      else if (_coinFilter.GetEntitiesCount() <= 0)
        currentState = GameState.Dead;

      if (currentState == GameState.Play)
        return;

      ref var @event = ref _world.NewEntity().Set<GameStateChangedEvent>();
      @event.State = currentState;
    }
  }
}