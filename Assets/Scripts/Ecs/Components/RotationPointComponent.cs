using System.Collections.Generic;
using UnityEngine;

namespace Ecs.Components
{
  public struct RotationPointComponent
  {
    public List<Vector3> Directions;
    public Vector3 Position;
  }
}