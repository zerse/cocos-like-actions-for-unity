using System;
using UnityEngine;

namespace CocosLikeActions {
  public class CLEaseOut : CLIntervalControlAction {
    protected float Rate { get { return rate; } }

    public CLEaseOut( CLIntervalAction action, float rate ) : base( action ) {
      this.rate = rate;
    }

    public override CLAction Clone() {
      return new CLEaseOut( Action, Rate );
    }

    public override CLAction Reverse() {
      var reversedAction = Action.Reverse() as CLIntervalAction;
//      var reversedRate = 1f / Rate;
//      return new CLEaseOut( reversedAction, reversedRate );
      return new CLEaseIn( reversedAction, Rate );
    }

    protected override float ProgressControl( float progress ) {
      return Mathf.Pow( progress, 1f / rate );
    }

    private float rate;
  }
}
