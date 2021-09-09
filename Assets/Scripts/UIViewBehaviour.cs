using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace UI.Component {
	[Serializable]
	public class UIViewBehaviour {
		public bool instantAnimation;
		[Expandable, Required] public UIAnimation animation;

		public IEnumerator ExecuteAnimation(UIView view, Action startCallback, Action endCallback) {
			yield return ExecuteAnimation(view, startCallback, endCallback, instantAnimation);
		}
		
		public IEnumerator ExecuteInstantAnimation(UIView view, Action startCallback, Action endCallback) {
			yield return ExecuteAnimation(view, startCallback, endCallback, true);
		}
		
		private IEnumerator ExecuteAnimation(UIView view, Action startCallback, Action endCallback, bool instant) {
			
			startCallback?.Invoke();
			
			UIAnimator.Move(view.rectTransform, animation, instant);
			UIAnimator.Rotate(view.rectTransform, animation, instant);
			UIAnimator.Scale(view.rectTransform, animation, instant);
			UIAnimator.Fade(view.canvasGroup, animation, instant);

			if (!instant && animation.TotalDuration >= 0)
				yield return new WaitForSecondsRealtime(animation.TotalDuration);
			
			endCallback?.Invoke();
		} 
	}
}