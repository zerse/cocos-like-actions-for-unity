using System;

namespace CocosLikeActions {
  public abstract class CLInstantAction : CLFiniteTimeAction {
    protected CLInstantAction() : base( 0.0f ) {
    }

    protected override void Start() {
      Update( 1.0f );
      Stop();
    }

    protected override void Step( float deltaTime ) {
      throw new NotSupportedException( "InstantAction does not suppport Step()" );
    }
  }
}
