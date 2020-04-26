using System;
using System.Collections.Generic;
using System.Linq;
using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects.Implementations
{
  public class RotationPointViewObject : ViewObject
  {
    [SerializeField]
    private List<DirectionType> _directions;
    
    protected override void Inject(EcsWorld world)
    {
      var entity = world.NewEntity();
      ref var component = ref entity.Set<RotationPointComponent>();
      component.Directions = _directions.Select(t => t.ToVector3()).ToList();
      component.Position = gameObject.transform.position;
    }
  }

  public enum DirectionType
  {
    Left,
    Right,
    Top,
    Bottom
  }

  public static class EnumExtensions
  {
    public static Vector3 ToVector3(this DirectionType type)
    {
      switch (type)
      {
        case DirectionType.Left:
          return Vector3.left;
        case DirectionType.Right:
          return Vector3.right;
        case DirectionType.Top:
          return Vector3.forward;
        case DirectionType.Bottom:
          return Vector3.back;
        default:
          throw new ArgumentOutOfRangeException(nameof(type), type, null);
      }
    }
  }
}