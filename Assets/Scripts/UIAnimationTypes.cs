using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Component {
	public partial class UIAnimation {
		[Serializable]
		public class MoveAnimation {
			public bool enabled;
			public Vector3 from;
			public Vector3 to;
			public Ease ease = Ease.Linear;
			public float startDelay;
			public float duration;
		}

		[Serializable]
		public class RotateAnimation {
			public bool enabled;
			public Vector3 from;
			public Vector3 to;
			public Ease ease = Ease.Linear;
			public float startDelay;
			public float duration;
			public RotateMode rotateMode;
		}

		[Serializable]
		public class ScaleAnimation {
			public bool enabled;
			public Vector3 from;
			public Vector3 to;
			public Ease ease = Ease.Linear;
			public float startDelay;
			public float duration;
		}
		
		[Serializable]
		public class FadeAnimation {
			public bool enabled;
			 public float from;
			 public float to;
			 public Ease ease = Ease.Linear;
			 public float startDelay;
			 public float duration;
			 public bool canvasEnabledDuringAnimation;
		}
	}
}