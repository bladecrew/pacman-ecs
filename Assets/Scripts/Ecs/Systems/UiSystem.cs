using System.Globalization;
using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Ecs.Systems
{
  public class UiSystem : IEcsRunSystem, IEcsInitSystem
  {
    private EcsFilter<PacmanComponent> _filter;

    private EcsFilter<GameStateChangedEvent> _eventsFilter;

    [EcsUiNamed("CoinsText")]
    private Text _coinsText;

    [EcsUiNamed("HealthText")]
    private Text _healthText;

    [EcsUiNamed("LooseGroup")]
    private GameObject _looseGrop;

    [EcsUiNamed("WinGroup")]
    private GameObject _winGroup;

    public void Init()
    {
      _looseGrop.gameObject.SetActive(false);
      _winGroup.gameObject.SetActive(false);
    }

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
        _looseGrop.gameObject.SetActive(@event.State == GameState.Dead);
        _winGroup.gameObject.SetActive(@event.State == GameState.Win);
      }
    }
  }
}