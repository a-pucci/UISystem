using System;
using NaughtyAttributes;
using UnityEngine;
using Utilities.Extensions;

namespace UI.Component {
	[RequireComponent(typeof(CanvasGroup)), RequireComponent(typeof(Canvas))]
	public class UIView : MonoBehaviour {
		private enum State {
			NotVisible,
			Hiding,
			Visible,
			Showing
		}

		[HideInInspector] public Canvas canvas;
		[HideInInspector] public CanvasGroup canvasGroup;
		[HideInInspector] public RectTransform rectTransform;

		[SerializeField] private State startingState = State.NotVisible;

		[SerializeField] private bool hasOnBack;
		[ShowIf(nameof(hasOnBack)), SerializeField, Label("Return To")]
		private UIView previousView = default;
		
		[SerializeField] private bool hasCustomStartPosition;
		[SerializeField, ShowIf(nameof(hasCustomStartPosition))]
		private Vector2 startPosition;

		[BoxGroup("Show")]
		public UIViewBehaviour showBehaviour;

		[BoxGroup("Hide")]
		public UIViewBehaviour hideBehaviour;

		public GameObject selectedObject;
		
		public event Action ShowStart;
		public event Action ShowEnd;
		public event Action HideStart;
		public event Action HideEnd;

		private State state;

		private void Awake() {
			canvas = GetComponent<Canvas>();
			canvasGroup = GetComponent<CanvasGroup>();
			rectTransform = GetComponent<RectTransform>();
		}

		private void Start() {
			rectTransform.anchoredPosition = hasCustomStartPosition ? startPosition : Vector2.zero;

			if (startingState == State.NotVisible) Hide(true);
			if (startingState == State.Hiding) Hide(false);
			if (startingState == State.Visible) Show(true);
			if (startingState == State.Showing) Show(false);
		}

		private void OnDestroy() => UIBackButton.GoingBack -= OnBack;
		
		#region Show

		private void Show(bool instant) {
			UIBackButton.GoingBack += OnBack;
			if (instant) 
				StartCoroutine(showBehaviour.ExecuteInstantAnimation(this, OnShowStart, OnShowEnd));
			else
				StartCoroutine(showBehaviour.ExecuteAnimation(this, OnShowStart, OnShowEnd));
		}

		public void InstantShow() {
			if (state == State.Visible || state == State.Showing)
				return;
			Show(true);
		}

		public void Show() {
			if (state == State.Visible || state == State.Showing)
				return;
			Show(false);
		}

		private void OnShowStart() {
			state = State.Showing;
			canvas.enabled = true;
			ShowStart?.Invoke();
		}

		private void OnShowEnd() {
			state = State.Visible;
			canvasGroup.Show(true);
			if (selectedObject)
				UINavigation.UpdateSelectedObject(selectedObject);
			ShowEnd?.Invoke();
		}

		#endregion

		#region Hide

		private void Hide(bool instant) {
			UIBackButton.GoingBack -= OnBack;
			if(instant)
				StartCoroutine(hideBehaviour.ExecuteInstantAnimation(this, OnHideStart, OnHideEnd));
			else
				StartCoroutine(hideBehaviour.ExecuteAnimation(this, OnHideStart, OnHideEnd));

		}
		
		public void InstantHide() {
			if (state == State.NotVisible || state == State.Hiding)
				return;
			Hide(true);
		}

		public void Hide() {
			if (state == State.NotVisible || state == State.Hiding)
				return;
			Hide(false);
		}

		private void OnHideStart() {
			state = State.Hiding;
			HideStart?.Invoke();
		}

		private void OnHideEnd() {
			state = State.NotVisible;
			canvasGroup.Show(false);
			canvas.enabled = false;
			HideEnd?.Invoke();
		}

		#endregion

		#region Back

		private void OnBack() {
			if (!hasOnBack)
				return;
			previousView.Show();
			Hide();
		}

		#endregion
	}
}