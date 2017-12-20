using UnityEngine;

namespace CocosLikeActions {
  public class CLEaseIn : CLIntervalControlAction {
    protected float Rate { get { return rate; } }

    public CLEaseIn( CLIntervalAction action, float rate ) : base( action ) {
      this.rate = rate;
    }

    public override CLAction Clone() {
      return new CLEaseIn( Action, Rate );
    }

    public override CLAction Reverse() {
      var reversedAction = Action.Reverse() as CLIntervalAction;
//      var reversedRate = 1f / Rate;
//      return new CLEaseIn( reversedAction, reversedRate );
      return new CLEaseOut( reversedAction, Rate );
    }

    protected override float ProgressControl( float progress ) {
      return Mathf.Pow( progress, rate );
    }

    private float rate;
  }
}
