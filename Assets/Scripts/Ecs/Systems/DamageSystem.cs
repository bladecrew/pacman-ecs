using System.Linq;
using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class DamageSystem : IEcsRunSystem
  {
    private EcsFilter<CollisionEvent> _filter;
    private EcsFilter<PacmanComponent> _pacmanFilter;

    public void Run()
    {
      foreach (var index in _filter)
      {
        var target = _filter.Get1(index).Target;
        var teaser = _filter.Get1(index).Teaser;

        var pacman = _pacmanFilter
          .Where(x => x.Object == teaser)
          .FirstOrDefault();

        if (pacman == PacmanComponent.Null)
          return;

        Debug.Log("Collision detected");
      }
    }
  }
}