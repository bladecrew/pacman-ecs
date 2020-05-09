using Ecs;
using Ecs.ViewObjects.Implementations;
using Leopotam.Ecs;
using UnityEngine;

namespace Services
{
  public class CoinSpawningService
  {
    private CoinViewObject _coin;

    public CoinSpawningService(CoinViewObject coin)
    {
      _coin = coin;
    }

    public void Spawn(EcsWorld world, Vector3 startPosition, Vector3 endPosition)
    {
      var distance = Vector3.Distance(startPosition, endPosition);
        
      for (var i = 1; i < distance; i++)
      {
        var position = Vector3.MoveTowards(startPosition, endPosition, i);
        if(position.normalized == endPosition.normalized || position.normalized == startPosition.normalized)
          continue;
        
        world.NewViewObject(_coin, position);
      }
    }
  }
}