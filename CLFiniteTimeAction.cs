using UnityEngine;

namespace CocosLikeActions {
  public abstract class CLFiniteTimeAction : CLAction {
    public float Duration { get { return duration; } }

    public CLFiniteTimeAction( float duration ) {
      this.duration = duration;
    }

    private float duration;
  }
}
