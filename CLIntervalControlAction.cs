using System;

namespace CocosLikeActions {
  public abstract class CLIntervalControlAction : CLIntervalAction {
    protected CLIntervalAction  Action { get { return action; } }

    protected CLIntervalControlAction( CLIntervalAction action ) : base( action.Duration ) {
      this.action = action;

      actionStart = GetStartDelegate( action );
      actionStop = GetStopDelegate( action );
      actionUpdate = GetUpdateDelegate( action );
    }

    protected abstract float ProgressControl( float progress );

    protected override void Start() {
      base.Start();
      actionStart();
    }

    protected override void Update( float progress ) {
      actionUpdate( ProgressControl( progress ) );
    }

    protected override void Stop() {
      actionStop();
      base.Stop();
    }

    private CLIntervalAction action;

    private Action actionStart;
    private Action<float> actionUpdate;
    private Action actionStop;
  }
}