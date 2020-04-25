using UnityEngine;

namespace Ecs.Components
{
  public struct MovementComponent
  {
    public float Speed;
    public GameObject Object;
    public Vector3 Direction;
  }
}