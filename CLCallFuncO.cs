using System;

namespace CocosLikeActions {
  using SEL_CallFuncO = System.Action<System.Object>;

  public class CLCallFuncO : CLGenericCallFunc<SEL_CallFuncO> {
    protected object Object { get { return obj; } }

    public CLCallFuncO( SEL_CallFuncO callback, object obj ) : this( callback, null, obj ) { }

    public CLCallFuncO( SEL_CallFuncO callback, SEL_CallFuncO reverseCallback, object obj ) : base( callback, reverseCallback ) {
      this.obj = obj;
    }

    public override CLAction Clone() {
      return new CLCallFuncO( Callback, ReverseCallback, obj );
    }

    public override CLAction Reverse() {
      if ( ReverseCallback == null ) {
        throw new MissingFieldException( GetType().ToString(), "ReverseCallback" );
      }

      return new CLCallFuncO( ReverseCallback, Callback, obj );
    }

    protected override void Execute() {
      Callback( Object );
    }

    private object obj;
  }
}