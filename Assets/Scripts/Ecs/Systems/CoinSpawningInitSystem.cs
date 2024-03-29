using System.Collections.Generic;
using System.Linq;
using Ecs.Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Ecs.Systems
{
  public class CoinSpawningInitSystem : IEcsInitSystem
  {
    private CoinSpawningService _coinSpawningService;
    private RaycastService _raycastService;
    private EcsFilter<PacmanComponent> _pacmanFilter;
    private EcsWorld _world;
    
    public void Init()
    {
      var pacmanEcsData = _pacmanFilter.FirstOrDefault();
      if (pacmanEcsData == null)
        return;

      var startPosition = pacmanEcsData.Component.Object.transform.position;
      var seeingPoints = _raycastService.SeeingPoints(startPosition).ToArray();

      foreach (var point in seeingPoints)
        FindPlaceAndSpawn(point);
    }

    private readonly List<Vector3> _filledPositions = new List<Vector3>();
    private void FindPlaceAndSpawn(Vector3 startPosition)
    {
      var seeingPoints = _raycastService.SeeingPoints(startPosition).Except(_filledPositions).ToArray();

      if (seeingPoints.Length == 0)
        return;
      
      _filledPositions.Add(startPosition);

      foreach (var endPosition in seeingPoints)
      {
        _coinSpawningService.Spawn(_world, startPosition, endPosition);
        FindPlaceAndSpawn(endPosition);
      }
    }
  }
}