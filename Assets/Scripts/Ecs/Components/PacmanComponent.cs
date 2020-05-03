using UnityEngine;

namespace Ecs.Components
{
  public struct PacmanComponent
  {
    public float Health;
    public float Points;
    public GameObject Object;

    public static bool operator ==(PacmanComponent x, PacmanComponent y) => x.Equals(y);

    public static bool operator !=(PacmanComponent x, PacmanComponent y) => !x.Equals(y);

    public override bool Equals(object obj)
    {
      return obj is PacmanComponent other && 
             Equals(Health, other.Health) && 
             Equals(Points, other.Points) && 
             Equals(Object, other.Object);
    }

    public override int GetHashCode()
    {
      return Health.GetHashCode() ^ Points.GetHashCode() ^ (Object != null ? Object.GetHashCode() : 0);
    }
  }
}