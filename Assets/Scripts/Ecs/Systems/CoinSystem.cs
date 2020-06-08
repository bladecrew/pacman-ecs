using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class CoinSystem : IEcsRunSystem
  {
    private EcsFilter<CollisionEvent> _eventFilter;
    private EcsFilter<CoinComponent> _coinFilter;
    private EcsFilter<PacmanComponent> _pacmanFilter;
    
    public void Run()
    {
      foreach (var index in _eventFilter)
      {
        var coin = _coinFilter.FirstOrDefault(x => x.Target == _eventFilter.Get1(index).Target);
        
        if(coin == null)
          continue;

        var pacman = _pacmanFilter.FirstOrDefault();
        if(pacman == null)
          continue;

        ref var pacmanComponent = ref pacman.Entity.Set<PacmanComponent>();
        pacmanComponent.Points += coin.Component.Points;
        
        Object.Destroy(coin.Component.Target);
        
        coin.Entity.Destroy();
      }
    }
  }
}