using Ecs.Components.Events;
using Ecs.Systems;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Ecs
{
  public class GameManager : MonoBehaviour
  {
    public EcsWorld World = new EcsWorld();

    [SerializeField]
    private GameObject[] _rotationPoints;
    
    private EcsSystems _systems;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
      Instance = this;
      _systems = new EcsSystems(World);
      _systems
        .Add(new FindingDirectionSystem())
        .Add(new InputSystem())
        .Add(new MovementSystem())
        .Add(new DamageSystem())
        .OneFrame<CollisionEvent>()
        .Inject(new RaycastService(_rotationPoints))
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