using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Component {
	[RequireComponent(typeof(Button))]
	public class UIButton : UISelectable {
		[SerializeField] protected bool blinkOnClick = true;

		[SerializeField, OnValueChanged("ChangeVisibility")]
		protected bool notAvailable = default;
		public bool NotAvailable {
			get => notAvailable;
			set {
				notAvailable = value;
				ChangeVisibility();
			}
		}
		[Space(20)]
		[SerializeField] protected bool changeViewOnClick;
		[ShowIf(nameof(changeViewOnClick)), SerializeField, Label("Show")] 
		protected UIView viewToShow = default;
		[ShowIf(nameof(changeViewOnClick)), SerializeField, Label("Hide")] 
		protected UIView viewToHide = default;
		private Button button;
		
		protected override void Awake() {
			base.Awake();
			AddOnClickButtonEvent();
		}

		protected void AddOnClickButtonEvent() {
			button = GetComponent<Button>();
			button.onClick.AddListener(OnClick);
		}

		protected virtual void Start() => SetUnpressed();
		
		protected virtual void ChangeVisibility() {}

		public virtual void OnClick() {
			if (gameObject.activeInHierarchy) {
				if (notAvailable) {
					StartCoroutine(ErrorFlash());
					return;
				}
				if (blinkOnClick) 
					StartCoroutine(MakeDoubleFlash(ChangeView));
				else {
					SetPressed();
					ChangeView();
				}
			}
		}

		protected void ChangeView() {
			if (!changeViewOnClick) return;
			if(viewToShow) viewToShow.Show();
			if(viewToHide) viewToHide.Hide();
		}
	}
}