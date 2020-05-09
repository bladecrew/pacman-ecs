using Ecs.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects
{
  public abstract class ViewObject : MonoBehaviour
  {
    public abstract void Inject(EcsWorld world);
    
    #region Unity Events
    
    private void OnTriggerEnter(Collider other)
    {
      var entity = GameManager.Instance.World.NewEntity();
      ref var component = ref entity.Set<CollisionEvent>();
      component.Target = other.gameObject;
      component.Teaser = gameObject;
    }

    #endregion
  }
}