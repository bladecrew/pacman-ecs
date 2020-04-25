using System;
using System.Collections.Generic;

namespace Model
{
  [Serializable]
  public class Pacman
  {
    public float Points;
    public List<Gun> Guns;
  }

  public class Gun
  {
    public int Id;
    public string Name;
    public float Damage;
  }

  public class Gangster
  {
    public int Id;
    public string Name;
    public float Damage;
  }

  public class World
  {
    public Pacman Pacman;
    public List<District> Districts;
  }

  public class District
  {
    public List<Gangster> Gangsters;
    public List<Joint> Joints;
  }

  public class Joint
  {
    public float Points;
  }
}