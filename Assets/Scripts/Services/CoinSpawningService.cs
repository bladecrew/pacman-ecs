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
      world.NewViewObject(_coin, endPosition);
    }
  }
}