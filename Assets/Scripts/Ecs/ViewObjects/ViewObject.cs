using System.Collections;
using Ecs.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects
{
  public abstract class ViewObject : MonoBehaviour
  {
    #region Unity Events
    
    private void Awake()
    {
      if (GameManager.Instance != null)
      {
        Inject(GameManager.Instance.World);
        return;
      }

      StartCoroutine(WaitInitializationThread());
      IEnumerator WaitInitializationThread()
      {
        while(GameManager.Instance == null)
          yield return new WaitForEndOfFrame();
        
        Awake();
      }
    }
    
    private void OnTriggerEnter(Collider other)
    {
      var entity = GameManager.Instance.World.NewEntity();
      ref var component = ref entity.Set<CollisionEvent>();
      component.Target = other.gameObject;
      component.Teaser = gameObject;
    }

    #endregion

    protected abstract void Inject(EcsWorld world);
  }
}