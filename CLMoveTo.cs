using System;
using UnityEngine;

namespace CocosLikeActions {
  public class CLMoveTo : CLMoveBy {
    public CLMoveTo( float duration, Vector2 destination ) : base( duration ) {
      this.destination = new Vector3( destination.x, destination.y, 0f );
    }

    public override CLAction Clone() {
      return new CLMoveTo( Duration, destination );
    }

    public override CLAction Reverse() {
      throw new NotSupportedException( "CLMoveTo does not support Reverse()" );
    }

    protected override void Start() {
      PositionDelta = destination - Target.transform.position;

      base.Start();
    }

    protected override void Stop() {
      Target.transform.position = destination;

      base.Stop();
    }

    private Vector3 destination;
  }
}