using Model;
using UnityEngine;

namespace Ecs.Components
{
  public struct PacmanComponent
  {
    public Pacman Pacman;
    public GameObject Object;

    public static bool operator ==(PacmanComponent x, PacmanComponent y) => x.Equals(y);

    public static bool operator !=(PacmanComponent x, PacmanComponent y) => !x.Equals(y);

    public override bool Equals(object obj)
    {
      return obj is PacmanComponent other && Equals(Pacman, other.Pacman) && Equals(Object, other.Object);
    }

    public override int GetHashCode()
    {
      return ((Pacman != null ? Pacman.GetHashCode() : 0) * 397) ^ (Object != null ? Object.GetHashCode() : 0);
    }
  }
}