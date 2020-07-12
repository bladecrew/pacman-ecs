using System.Globalization;
using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Ecs.Systems
{
  public class UiSystem : IEcsRunSystem
  {
    private EcsFilter<PacmanComponent> _filter;

    private EcsFilter<GameStateChangedEvent> _eventsFilter;

    [EcsUiNamed("CoinsText")]
    private Text _coinsText;

    [EcsUiNamed("HealthText")]
    private Text _healthText;

    public void Run()
    {
      foreach (var index in _filter)
      {
        var component = _filter.Get1(index);

        _coinsText.text = component.Points.ToString(CultureInfo.CurrentCulture);
        _healthText.text = component.Health.ToString(CultureInfo.CurrentCulture);
      }

      foreach (var index in _eventsFilter)
      {
        var @event = _eventsFilter.Get1(index);

        if (@event.State != GameState.Play)
          Time.timeScale = 0f;
      }
    }
  }
}