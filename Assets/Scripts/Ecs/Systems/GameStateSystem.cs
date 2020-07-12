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
      
      foreach (var index in _pacmanFilter)
      {
        var pacman = _pacmanFilter.Get1(index);

        if (pacman.Health <= 0)
          currentState = GameState.Dead;
      }
      
      if (currentState != GameState.Play)
      {
        ref var @event = ref _world.NewEntity().Set<GameStateChangedEvent>();
        @event.State = currentState;
      }
      else
      {
        var coinsCount = _coinFilter.GetEntitiesCount();

        if (coinsCount > 0)
          return;
        
        ref var @event = ref _world.NewEntity().Set<GameStateChangedEvent>();
        @event.State = GameState.Win;
      }
    }
  }
}