using System;
using UnityEngine;

namespace CocosLikeActions {
  using SEL_CallFuncN = Action<GameObject>;

  public class CLCallFuncN : CLGenericCallFunc<SEL_CallFuncN> {
    public CLCallFuncN( SEL_CallFuncN callback ) : this( callback, null ) { }

    public CLCallFuncN( SEL_CallFuncN callback, SEL_CallFuncN reverseCallback ) : base( callback, reverseCallback ) {
    }

    public override CLAction Clone() {
      return new CLCallFuncN( Callback, ReverseCallback );
    }

    public override CLAction Reverse() {
      if ( ReverseCallback == null ) {
        throw new MissingFieldException( GetType().ToString(), "ReverseCallback" );
      }

      return new CLCallFuncN( ReverseCallback, Callback );
    }

    protected override void Execute() {
      Callback( Target );
    }
  }
}