using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Component {
	public class UIDropdown : UISelectable {
		[SerializeField] private TextMeshProUGUI dropdownLabel;
		[SerializeField] private Image arrow;
		[SerializeField] private TMP_Dropdown dropdown;

		public List<TMP_Dropdown.OptionData> Options {
			get => dropdown.options;
			set => dropdown.options = value;
		}

		public int Value {
			get => dropdown.value;
			set => dropdown.value = value;
		}
		public bool IsExpanded => dropdown.IsExpanded;

		public override void SetUnpressed() {
			base.SetUnpressed();
			arrow.color = settings.Unpressed.label;
			dropdownLabel.color = settings.Unpressed.label;
		}

		public override void SetPressed() {
			base.SetPressed();
			arrow.color = settings.Pressed.label;
			dropdownLabel.color = settings.Pressed.label;
		}

		public override void SetSelected() {
			base.SetSelected();
			arrow.color = settings.Selected.label;
			dropdownLabel.color = settings.Selected.label;
		}

		public override void SetError() {
			base.SetError();
			arrow.color = settings.Error.label;
			dropdownLabel.color = settings.Error.label;
		}

		public void AddListener(UnityAction<int> action) => dropdown.onValueChanged.AddListener(action);
		
		public void RemoveAllListeners() => dropdown.onValueChanged.RemoveAllListeners();
		
		public void Hide() => dropdown.Hide();
		
	}
}