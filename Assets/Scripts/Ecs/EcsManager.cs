using Ecs.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs
{
  public class EcsManager : MonoBehaviour
  {
    public EcsWorld World = new EcsWorld();
  
    private EcsSystems _systems;

    public static EcsManager Instance { get; private set; }

    private void Start()
    {
      Instance = this;
      _systems = new EcsSystems(World);
      _systems
        .Add(new InputSystem())
        .Add(new MovementSystem())
        .Init();
    
#if UNITY_EDITOR
      Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
      Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
    }

    private void Update()
    {
      _systems?.Run();
    }

    private void OnDestroy()
    {
      if (_systems == null)
        return;
    
      _systems.Destroy();
      _systems = null;
      
      World.Destroy();
    }
  }
}