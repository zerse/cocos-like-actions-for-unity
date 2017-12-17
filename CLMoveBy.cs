using System;
using UnityEngine;

namespace CocosLikeActions {
  public class CLMoveBy : CLIntervalAction {
    protected Vector3 PositionDelta {
      get { return positionDelta; }
      set { positionDelta = value; }
    }

    public CLMoveBy( float duration, Vector2 relative ) : base( duration ) {
      positionDelta = new Vector3( relative.x, relative.y, 0f );
    }

    protected CLMoveBy( float duration ) : base( duration ) {
    }

    public override CLAction Clone() {
      return new CLMoveBy( Duration, PositionDelta );
    }

    public override CLAction Reverse() {
      return new CLMoveBy( Duration, - PositionDelta );
    }

    protected override void Start() {
      startPosition = Target.transform.position;

      base.Start();
    }

    protected override void Update( float progress ) {
      Target.transform.position = startPosition + (positionDelta * progress);
    }

    private Vector3 startPosition;
    private Vector3 positionDelta;
  }
}