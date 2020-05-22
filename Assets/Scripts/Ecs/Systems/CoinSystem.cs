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
    
    public void Run()
    {
      foreach (var index in _eventFilter)
      {
        var coin = _coinFilter.FirstOrDefault(x => x.Target == _eventFilter.Get1(index).Target);
        
        if(coin == null)
          continue;
        
        Debug.Log("Coin Getted!");
      }
    }
  }
}