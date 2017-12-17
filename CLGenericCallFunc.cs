
namespace CocosLikeActions {
  public abstract class CLGenericCallFunc<TCallback> : CLInstantAction {
    protected TCallback Callback { get { return callback; } }
    protected TCallback ReverseCallback { get { return reverseCallback; } }

    protected CLGenericCallFunc( TCallback callback, TCallback reverseCallback ) {
      this.callback = callback;
      this.reverseCallback = reverseCallback;
    }

    protected override void Update( float progress ) {
      Execute();
    }

    protected abstract void Execute();

    private TCallback callback;
    private TCallback reverseCallback;
  }
}