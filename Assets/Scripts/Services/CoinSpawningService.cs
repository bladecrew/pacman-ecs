using UnityEngine;

namespace Services
{
  public class CoinSpawningService
  {
    private GameObject _coin;
    private GameObject[] _rotationPoints;

    public CoinSpawningService(GameObject coin, GameObject[] rotationPoints)
    {
      _coin = coin;
      _rotationPoints = rotationPoints;
    }

    public void Spawn()
    {
      /**
       * todo : iterate on rotation points for finding corners
       * todo : then spawn coin objects between rotation points
       */
    }
  }
}