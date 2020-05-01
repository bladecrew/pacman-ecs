using System;
using System.Collections.Generic;
using Leopotam.Ecs;

namespace Ecs
{
  public static class EcsExtensions
  {
    public static IEnumerable<T> Where<T>(this EcsFilter<T> filter, Func<T, bool> predicate)
      where T : struct
    {
      var result = new List<T>();
      
      foreach (var index in filter)
      {
        var component = filter.Get1(index);
        if(predicate.Invoke(component))
          result.Add(component);
      }

      return result;
    }
  }
}