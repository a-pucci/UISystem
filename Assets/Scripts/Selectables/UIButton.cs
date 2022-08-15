using UnityEngine;
using UnityEngine.UI;

namespace UI.Component {
	[RequireComponent(typeof(Button))]
	public class UIButton : UISelectable {
		[SerializeField]
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
		[SerializeField] 
		protected UIView viewToShow = default;
		[SerializeField] 
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
		
		public virtual void ChangeVisibility() {}

		public virtual void OnClick() {
			if (gameObject.activeInHierarchy) {
				if (notAvailable) {
					StartCoroutine(ErrorFlash());
					return;
				}
				
				SetPressed();
				ChangeView();
			}
		}

		protected void ChangeView() {
			if (!changeViewOnClick) return;
			if(viewToShow) viewToShow.Show();
			if(viewToHide) viewToHide.Hide();
		}
	}
}