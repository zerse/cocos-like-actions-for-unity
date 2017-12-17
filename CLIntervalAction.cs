using System;
using UnityEngine;

namespace CocosLikeActions {
  public abstract class CLIntervalAction : CLFiniteTimeAction {
    protected float ElapsedTime { get { return elapsedTime; } }

    protected CLIntervalAction( float duration ) : base( duration ) {
    }

    protected override void Start() {
      elapsedTime = 0.0f;

      // if Duration is Zero, just run like InstantAction
      // Step() never being called
      if ( Duration == 0.0f ) {
        Update( 1.0f );
        Stop();
      }
    }

    protected override void Step( float deltaTime ) {
      elapsedTime += deltaTime;

      // Start() will check whether Duration is zero,
      // so it does not need to check division-by-zero exception here
      var progress = elapsedTime / Duration;
      if ( progress >= 1.0f ) {
        Update( 1.0f );
        Stop();
      } else {
        Update( progress );
      }
    }

    private float elapsedTime;
  }
}