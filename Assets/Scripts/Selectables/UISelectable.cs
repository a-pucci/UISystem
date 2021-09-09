using System;
using System.Collections;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Component {
	public abstract class UISelectable : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerClickHandler {
		[SerializeField] protected Image fill;
		[SerializeField] protected Image border;

		[SerializeField] protected TextMeshProUGUI label;
		[SerializeField] protected bool deselectAfterClick = true;

		[SerializeField, BoxGroup, Expandable] protected UIComponentSettings settings = default;
		
		[HideInInspector] public RectTransform rectTransform;
		
		protected CanvasGroup canvasGroup;
		
		protected virtual void Awake() {
			rectTransform = GetComponent<RectTransform>();
			canvasGroup ??= TryGetComponent(out CanvasGroup cg) ? cg : gameObject.AddComponent<CanvasGroup>();
		}
		
		public virtual void OnSelect(BaseEventData eventData) {
			StartCoroutine(ExecuteAnimation(settings.Animations.selectAnimation));
			SetSelected();
		}

		public virtual void OnDeselect(BaseEventData eventData) {
			StartCoroutine(ExecuteAnimation(settings.Animations.deselectAnimation));
			SetUnpressed();
		}

		public virtual void OnPointerEnter(PointerEventData eventData) {
			UINavigation.UpdateSelectedObject(gameObject);
			StartCoroutine(ExecuteAnimation(settings.Animations.selectAnimation));
			SetSelected();
		}

		public virtual void OnPointerClick(PointerEventData eventData) {
			StartCoroutine(ExecuteAnimation(settings.Animations.confirmAnimation));
		}

		[Button]
		public virtual void SetUnpressed() {
			if (fill) fill.color = settings.Unpressed.fill;
			if (border) border.color = settings.Unpressed.border;
			if (label) label.color = settings.Unpressed.label;
		}

		[Button]
		public virtual void SetSelected() {
			if (fill) fill.color = settings.Selected.fill;
			if (border) border.color = settings.Selected.border;
			if (label) label.color = settings.Selected.label;
		}

		[Button]
		protected virtual void SetPressed() {
			if (fill) fill.color = settings.Pressed.fill;
			if (border) border.color = settings.Pressed.border;
			if (label) label.color = settings.Pressed.label;
		}

		[Button]
		protected virtual void SetError() {
			if (fill) fill.color = settings.Error.fill;
			if (border) border.color = settings.Error.border;
			if (label) label.color = settings.Error.label;
		}

		protected IEnumerator MakeDoubleFlash(Action onEndAction = null) {
			var wait = new WaitForSecondsRealtime(settings.BlinkSettings.confirmFlashTime);
			for (int i = 0; i < settings.BlinkSettings.confirmFlashes; i++) {
				SetPressed();
				yield return wait;
				SetSelected();
				yield return wait;
			}
			SetPressed();
			yield return new WaitForSecondsRealtime(0.2f);
			if (deselectAfterClick)
				SetUnpressed();
			else
				SetSelected();
			
			onEndAction?.Invoke();
		}

		protected IEnumerator ErrorFlash() {
			StartCoroutine(ExecuteAnimation(settings.Animations.errorAnimation));
			SetError();
			yield return new WaitForSecondsRealtime(settings.BlinkSettings.errorFlashTime);
		}

		private IEnumerator ExecuteAnimation(UIAnimation uiAnimation) {
			if (uiAnimation == null)
				yield break;
			
			UIAnimator.PunchMove(rectTransform, uiAnimation);
			UIAnimator.PunchRotate(rectTransform, uiAnimation);
			UIAnimator.PunchScale(rectTransform, uiAnimation);
			UIAnimator.PunchFade(canvasGroup, uiAnimation);

			if (uiAnimation.TotalDuration >= 0)
				yield return new WaitForSecondsRealtime(uiAnimation.TotalDuration);
		}

	}
}