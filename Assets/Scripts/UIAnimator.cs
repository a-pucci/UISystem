using DG.Tweening;
using UnityEngine;

namespace UI.Component {
	public static class UIAnimator {
		#region Move

		public static void Move(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.MoveAnimation move = animation.Move;
			
			if (!move.enabled)
				return;
			
			if (instantAction) {
				target.anchoredPosition3D = move.to;
				return;
			}

			DOTween.Sequence()
				.SetUpdate(true)
				.Append(MoveTween(target, move, move.duration))
				.Play();
		}
		
		public static void PunchMove(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.MoveAnimation move = animation.Move;
			
			if (!move.enabled)
				return;                 
			
			if (instantAction) {
				target.anchoredPosition3D = move.to;
				return;
			}

			var backMove = new UIAnimation.MoveAnimation
			{
				from = move.to, 
				to = move.from, 
				duration = move.duration,
				ease = move.ease,
				startDelay = 0
			};
			
			DOTween.Sequence()
				.SetUpdate(true)
				.Append(MoveTween(target, move, move.duration/2))
				.Append(MoveTween(target, backMove, backMove.duration/2))
				.Play();
		}

		private static Tween MoveTween(RectTransform target, UIAnimation.MoveAnimation animation, float duration) {
			target.anchoredPosition3D = animation.from;
			Tweener tween = target.DOAnchorPos3D(animation.to, duration)
				.SetDelay(animation.startDelay)
				.SetUpdate(true);
			tween.SetEase(animation.ease);
			return tween;
		}

		#endregion

		#region Rotate

		public static void Rotate(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.RotateAnimation rotate = animation.Rotate;

			if (!rotate.enabled)
				return;

			if (instantAction) {
				target.localRotation = Quaternion.Euler(rotate.to);
				return;
			}

			DOTween.Sequence()
				.SetUpdate(true)
				.Append(RotateTween(target, rotate, rotate.duration))
				.Play();
		}
		
		public static void PunchRotate(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.RotateAnimation rotate = animation.Rotate;
			
			if (!rotate.enabled)
				return;                 
			
			if (instantAction) {
				target.localRotation = Quaternion.Euler(rotate.to);
				return;
			}

			var backRotate = new UIAnimation.RotateAnimation
			{
				from = rotate.to, 
				to = rotate.from,
				duration = rotate.duration,
				ease = rotate.ease,
				startDelay = 0
			};
			
			DOTween.Sequence()
				.SetUpdate(true)
				.Append(RotateTween(target, rotate, rotate.duration/2))
				.Append(RotateTween(target, backRotate, backRotate.duration/2))
				.Play();
		}

		private static Tween RotateTween(RectTransform target, UIAnimation.RotateAnimation animation, float duration) {
			target.localRotation = Quaternion.Euler(animation.from);
			Tweener tween = target.DOLocalRotate(animation.to, duration, animation.rotateMode)
				.SetDelay(animation.startDelay)
				.SetUpdate(true);
			tween.SetEase(animation.ease);
			return tween;
		}

		#endregion

		#region Scale

		public static void Scale(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.ScaleAnimation scale = animation.Scale;
			
			if (!scale.enabled)
				return;

			Vector3 startValue = scale.from;
			Vector3 endValue = scale.to;
			startValue.z = 1;
			endValue.z = 1;

			if (instantAction) {
				target.localScale = endValue;
				return;
			}

			DOTween.Sequence()
				.SetUpdate(true)
				.Append(ScaleTween(target, scale, startValue, endValue, scale.duration))
				.Play();
		}

		public static void PunchScale(RectTransform target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.ScaleAnimation scale = animation.Scale;
			
			if (!scale.enabled)
				return;        
			
			Vector3 startValue = scale.from;
			Vector3 endValue = scale.to;
			startValue.z = 1;
			endValue.z = 1;
			
			Vector3 backStartValue = scale.to;
			Vector3 backEndValue = scale.from;
			startValue.z = 1;
			endValue.z = 1;
			
			if (instantAction) {
				target.localScale = endValue;
				return;
			}

			var backScale = new UIAnimation.ScaleAnimation
			{
				ease = scale.ease,
				duration = scale.duration
			};
			
			DOTween.Sequence()
				.SetUpdate(true)
				.Append(ScaleTween(target, scale, startValue, endValue, scale.duration/2))
				.Append(ScaleTween(target, backScale, backStartValue, backEndValue, backScale.duration/2))
				.Play();
		} 
		
		private static Tween ScaleTween(RectTransform target, UIAnimation.ScaleAnimation animation, Vector3 startValue, Vector3 endValue, float duration) {
			target.localScale = startValue;
			Tweener tween = target.DOScale(endValue, duration)
				.SetDelay(animation.startDelay)
				.SetUpdate(true);
			tween.SetEase(animation.ease);
			return tween;
		}

		#endregion

		#region Fade

		public static void Fade(CanvasGroup target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.FadeAnimation fade = animation.Fade;
			
			if (!fade.enabled)
				return;

			if (instantAction) {
				target.alpha = fade.to;
				return;
			}

			DOTween.Sequence()
				.SetUpdate(true)
				.OnStart(() => {
					if (fade.canvasEnabledDuringAnimation) {
						target.interactable = true;
						target.blocksRaycasts = true;
					}
				})
				.Append(FadeTween(target, fade, fade.duration))
				.Play();
		}
		
		public static void PunchFade(CanvasGroup target, UIAnimation animation, bool instantAction = false) {
			UIAnimation.FadeAnimation fade = animation.Fade;
			
			if (!fade.enabled)
				return;        

			if (instantAction) {
				target.alpha = fade.to;
				return;
			}

			var backFade = new UIAnimation.FadeAnimation
			{
				from = fade.to,
				to = fade.from,
				ease = fade.ease,
				duration = fade.duration,
				startDelay = 0
			};
			
			DOTween.Sequence()
				.SetUpdate(true)
				.Append(FadeTween(target, fade, fade.duration/2))
				.Append(FadeTween(target, backFade, backFade.duration/2))
				.Play();
		} 
		
		private static Tween FadeTween(CanvasGroup target, UIAnimation.FadeAnimation animation, float duration) {
			target.alpha = animation.from;
			Tweener tween = target.DOFade(animation.to, duration)
				.SetDelay(animation.startDelay)
				.SetUpdate(true);
			tween.SetEase(animation.ease);
			return tween;
		}

		#endregion
	}
}