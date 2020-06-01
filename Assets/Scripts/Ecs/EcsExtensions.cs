using System;
using System.Collections.Generic;
using Ecs.ViewObjects;
using Leopotam.Ecs;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace Ecs
{
  public static class EcsExtensions
  {
    public static void NewViewObject(this EcsWorld world, ViewObject template, Vector3? position)
    {
      Object
        .Instantiate(template, position ?? Vector3.zero, Quaternion.identity)
        .Inject(world);
    }
    
    public static IEnumerable<EntityComponentPair<T>> Where<T>(this EcsFilter<T> filter, Func<T, bool> predicate)
      where T : struct
    {
      var result = new List<EntityComponentPair<T>>();

      foreach (var index in filter)
      {
        var component = filter.Get1(index);
        if (predicate.Invoke(component))
          result.Add(new EntityComponentPair<T>
          {
            Component = component,
            Entity = filter.GetEntity(index)
          });
      }

      return result;
    }

    public static EntityComponentPair<T> FirstOrDefault<T>(this EcsFilter<T> filter, Func<T, bool> predicate = null)
      where T : struct
    {
      foreach (var index in filter)
      {
        var component = filter.Get1(index);
        if (predicate == null || predicate.Invoke(component))
          return new EntityComponentPair<T>
          {
            Component = component,
            Entity = filter.GetEntity(index)
          };
      }

      return null;
    }

    public static bool IsDefault<T>(this T value)
      where T : struct
    {
      return value.Equals(new T());
    }
  }
}