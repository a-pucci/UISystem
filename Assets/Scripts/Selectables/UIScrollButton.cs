using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Component {
	public class UIScrollButton : UISelectable {
		public event Action<int> ChangedSelection;
		private int index;

		[SerializeField] private Button leftArrow = default;
		[SerializeField] private Button rightArrow = default;
		[SerializeField] private float scaleDuration = default;
		[SerializeField] private float scaleAmount = default;

		private RectTransform leftRect;
		private RectTransform rightRect;
		
		private List<string> data = new List<string>();

		public void Set(List<string> dataToSet) => data = dataToSet;
		
		private void Start() {
			SetUnpressed();
			leftArrow.onClick.RemoveAllListeners();
			rightArrow.onClick.RemoveAllListeners();
			leftArrow.onClick.AddListener(Previous);
			rightArrow.onClick.AddListener(Next);
			leftRect = leftArrow.GetComponent<RectTransform>();
			rightRect = rightArrow.GetComponent<RectTransform>();
		}
		
		private void Next() {
			index++;
			if (index == data.Count)
				index = 0;
			ChangedSelection?.Invoke(index);
			label.text = data[index];
			AnimateArrow(rightRect);
		}

		private void Previous() {
			index--;
			if (index == -1)
				index = data.Count - 1;
			ChangedSelection?.Invoke(index);
			label.text = data[index];
			AnimateArrow(leftRect);
		}

		public void ResetEvents() => ChangedSelection = null;
		
		public override void OnPointerClick(PointerEventData eventData) { }

		private void AnimateArrow(RectTransform rect) {
			var scale = new Vector3(rect.localScale.x, rect.localScale.y, rect.localScale.z);
			var endScale = new Vector3(scale.x + (scale.x * scaleAmount), scale.y + (scale.y * scaleAmount), scale.z);
			rect.DOScale(endScale, scaleDuration / 2).OnComplete(() => rect.DOScale(scale, scaleDuration / 2));
		}
	}
}