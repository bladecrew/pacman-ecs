using System.Globalization;
using Ecs.Components;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine.UI;

namespace Ecs.Systems
{
  public class UiSystem : IEcsRunSystem
  {
    private EcsFilter<PacmanComponent> _filter;
    
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
    }
  }
}