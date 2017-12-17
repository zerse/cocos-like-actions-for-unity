using UnityEngine;

namespace CocosLikeActions {
  public class CLHide : CLInstantAction {
    public override CLAction Clone() {
      return new CLHide();
    }

    public override CLAction Reverse() {
      return new CLShow();
    }

    protected override void Update( float progress ) {
      SetRendererDisabled( Target, false );
    }

    private static void SetRendererDisabled( GameObject gameObject, bool applyToChildren ) {
      var renderer = gameObject.GetComponent<Renderer>();
      if ( renderer != null && renderer.enabled ) {
        renderer.enabled = false;
      }

      if ( applyToChildren ) {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach ( var childRenderer in renderers ) {
          childRenderer.enabled = false;
        }
      }
    }
  }
}
