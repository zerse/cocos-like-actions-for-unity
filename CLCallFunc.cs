using System;

namespace CocosLikeActions {
  using SEL_CallFunc = Action;

  public class CLCallFunc : CLGenericCallFunc<SEL_CallFunc> {
    public CLCallFunc( SEL_CallFunc callback ) : this( callback, null ) { }

    public CLCallFunc( SEL_CallFunc callback, SEL_CallFunc reverseCallback ) : base( callback, reverseCallback) { }

    public override CLAction Clone() {
      return new CLCallFunc( Callback, ReverseCallback );
    }

    public override CLAction Reverse() {
      if ( ReverseCallback == null ) {
        throw new MissingFieldException( GetType().ToString(), "ReverseCallback" );
      }

      return new CLCallFunc( ReverseCallback, Callback );
    }

    protected override void Execute() {
      Callback();
    }
  }
}