using System;
using UnityEngine;

namespace CocosLikeActions {
  public abstract class CLIntervalAction : CLFiniteTimeAction {
    protected float ElapsedTime { get { return elapsedTime; } }

    protected CLIntervalAction( float duration ) : base( duration ) {
    }

    protected override void Start() {
      elapsedTime = 0.0f;
    }

    protected override void Step( float deltaTime ) {
      elapsedTime += deltaTime;

      if ( elapsedTime >= Duration ) {
        Update( 1.0f );
        Stop();
      } else {
        var progress = elapsedTime / Duration;
        Update( progress );
      }
    }

    private float elapsedTime;
  }
}