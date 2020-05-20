using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services
{
  public class RaycastService
  {
    private IEnumerable<GameObject> _filter;

    public RaycastService(IEnumerable<GameObject> filter)
    {
      _filter = filter;
    }

    public List<Vector3> SeeingPoints(Vector3 position, Vector3[] directions)
    {
      var result = new List<Vector3>();

      foreach (var direction in directions)
      {
        var objectsOnLines = Physics.RaycastAll(position, direction);

        result.AddRange(
          from hit in objectsOnLines
          where _filter.Contains(hit.transform.gameObject)
          select hit.transform.position
        );

#if UNITY_EDITOR
        Debug.DrawRay(position, direction, Color.green, 50, true);
#endif
      }

      return result;
    }

    public List<Vector3> SeeingPoints(Vector3 position)
    {
      return SeeingPoints(position, new[] {Vector3.forward, Vector3.left, Vector3.back, Vector3.right});
    }
  }
}