using Ecs.Components.Events;
using Ecs.Systems;
using Ecs.ViewObjects.Implementations;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using Services;
using UnityEngine;

namespace Ecs
{
  public class GameManager : MonoBehaviour
  {
    public EcsWorld World = new EcsWorld();

    [SerializeField]
    private GameObject[] _rotationPoints;

    [SerializeField]
    private CoinViewObject _coinObject;

    [SerializeField]
    private EcsUiEmitter _uiEmitter;
    
    private EcsSystems _systems;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
      Instance = this;
      _systems = new EcsSystems(World);
      
      _systems
        .Add(new ViewObjectsInitSystem())  
        .Add(new CoinSpawningInitSystem())
        .Add(new FindingDirectionSystem())
        .Add(new InputSystem())
        .Add(new MovementSystem())
        .Add(new DamageSystem())
        .Add(new CoinSystem())
        .Add(new GameStateSystem())
        .Add(new UiSystem())
        .OneFrame<CollisionEvent>()
        .OneFrame<GameStateChangedEvent>()
        .Inject(new RaycastService(_rotationPoints))
        .Inject(new CoinSpawningService(_coinObject))
        .InjectUi(_uiEmitter)
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