using Leopotam.Ecs;
using Services;

namespace Ecs.Systems
{
  public class CoinSpawningInitSystem : IEcsInitSystem
  {
    private CoinSpawningService _coinSpawningService;
    
    public void Init()
    {
      _coinSpawningService.Spawn();
    }
  }
}