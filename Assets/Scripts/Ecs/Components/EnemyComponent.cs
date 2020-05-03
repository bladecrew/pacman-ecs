using UnityEngine;

namespace Ecs.Components
{
  public struct EnemyComponent
  {
    public GameObject Object;
    public float Damage;

    public override bool Equals(object obj)
    {
      return obj is EnemyComponent other &&
             Equals(Object, other.Object) &&
             Equals(Damage, other.Damage);
    }

    public override int GetHashCode()
    {
      return Damage.GetHashCode() ^ (Object != null ? Object.GetHashCode() : 0);
    }
  }
}