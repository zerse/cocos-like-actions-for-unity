using System;
using UnityEngine;

namespace CocosLikeActions {
  public class CLCallFuncND<TData> : CLGenericCallFunc<Action<GameObject, TData>> {
    protected TData Data { get { return data; } }

    public CLCallFuncND( Action<GameObject, TData> callback, TData data ) : this( callback, null, data ) { }

    public CLCallFuncND( Action<GameObject, TData> callback, Action<GameObject, TData> reverseCallback, TData data ) : base( callback, reverseCallback ) {
      this.data = data;
    }

    public override CLAction Clone() {
      return new CLCallFuncND<TData>( Callback, ReverseCallback, Data );
    }

    public override CLAction Reverse() {
      if ( ReverseCallback == null ) {
        throw new MissingFieldException( GetType().ToString(), "ReverseCallback" );
      }

      return new CLCallFuncND<TData>( ReverseCallback, Callback, Data );
    }

    protected override void Execute() {
      Callback( Target, Data );
    }

    private TData data;
  }
}