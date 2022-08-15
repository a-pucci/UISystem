using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Component {
	public abstract class UISelectable : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerClickHandler {
		[SerializeField] protected Image fill;
		[SerializeField] protected Image border;

		[SerializeField] protected TextMeshProUGUI label;

		[SerializeField] protected UIComponentSettings settings;
		
		[HideInInspector] public RectTransform rectTransform;
		
		protected CanvasGroup canvasGroup;
		
		protected virtual void Awake() {
			rectTransform = GetComponent<RectTransform>();
			canvasGroup ??= TryGetComponent(out CanvasGroup cg) ? cg : gameObject.AddComponent<CanvasGroup>();
		}

		private void OnDisable() {
			SetUnpressed();
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
			UpdateSelectedObject();
			StartCoroutine(ExecuteAnimation(settings.Animations.selectAnimation));
			SetSelected();
		}

		public virtual void OnPointerClick(PointerEventData eventData) {
			StartCoroutine(ExecuteAnimation(settings.Animations.confirmAnimation));
		}

		public virtual void SetUnpressed() {
			if (fill) fill.color = settings.Unpressed.fill;
			if (border) border.color = settings.Unpressed.border;
			if (label) label.color = settings.Unpressed.label;
		}

		public virtual void SetSelected() {
			if (fill) fill.color = settings.Selected.fill;
			if (border) border.color = settings.Selected.border;
			if (label) label.color = settings.Selected.label;
		}

		public virtual void SetPressed() {
			if (fill) fill.color = settings.Pressed.fill;
			if (border) border.color = settings.Pressed.border;
			if (label) label.color = settings.Pressed.label;
		}

		public virtual void SetError() {
			if (fill) fill.color = settings.Error.fill;
			if (border) border.color = settings.Error.border;
			if (label) label.color = settings.Error.label;
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

		private void UpdateSelectedObject() {
			if (EventSystem.current.currentSelectedGameObject == gameObject)
				return;
			
			EventSystem.current.SetSelectedGameObject(gameObject);
		}
	}
}