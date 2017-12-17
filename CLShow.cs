using UnityEngine;

namespace CocosLikeActions {
  public class CLShow : CLInstantAction {
    public override CLAction Clone() {
      return new CLShow();
    }

    public override CLAction Reverse() {
      return new CLHide();
    }

    protected override void Update( float progress ) {
      SetRendererEnabled( Target, false );
    }

    private static void SetRendererEnabled( GameObject gameObject, bool applyToChildren ) {
      var renderer = gameObject.GetComponent<Renderer>();
      if ( renderer != null && ! renderer.enabled ) {
        renderer.enabled = true;
      }

      if ( applyToChildren ) {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach ( var childRenderer in renderers ) {
          childRenderer.enabled = true;
        }
      }
    }
  }
}
