using System;
using System.Collections;
using UnityEngine;

namespace CocosLikeActions {
  public abstract class CLAction {
    public bool IsDone { get { return done; } }
    //protected GameObject OriginalTarget { get { return originalTargetGameObject; } }
    protected GameObject Target { get { return targetGameObject; } }

    protected CLAction() {
      targetGameObject = null;
      //originalTargetGameObject = null;
    }

    public abstract CLAction Clone();
    public abstract CLAction Reverse();

    protected abstract void Start();
    protected abstract void Step( float deltaTime );
    protected abstract void Update( float progress );

    public IEnumerator StartAsCoroutine( GameObject target ) {
      StartWithTarget( target );
      yield return null;

      while ( ! done ) {
        Step( Time.deltaTime );
        yield return null;
      }
    }

    private void StartWithTarget( GameObject target ) {
      targetGameObject = target;
      done = false;

      Start();
    }

    protected virtual void Stop() {
      done = true;
    }

    /*
    */

    private GameObject targetGameObject;
    //private GameObject originalTargetGameObject;
    private bool done;
  }
}