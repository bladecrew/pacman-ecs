using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using Utils;

namespace Ecs
{
  public static class EcsExtensions
  {
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

    public static EntityComponentPair<T> FirstOrDefault<T>(this EcsFilter<T> filter, Func<T, bool> predicate)
      where T : struct
    {
      foreach (var index in filter)
      {
        var component = filter.Get1(index);
        if (predicate.Invoke(component))
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