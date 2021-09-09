using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace UI.Component {
	public partial class UIAnimation {
		[Serializable]
		public class MoveAnimation {
			public bool enabled;
			[ShowIf(nameof(enabled))] public Vector3 from;
			[ShowIf(nameof(enabled))] public Vector3 to;
			[ShowIf(nameof(enabled))] public Ease ease = Ease.Linear;
			[ShowIf(nameof(enabled))] public float startDelay;
			[ShowIf(nameof(enabled))] public float duration;
		}

		[Serializable]
		public class RotateAnimation {
			public bool enabled;
			[ShowIf(nameof(enabled))] public Vector3 from;
			[ShowIf(nameof(enabled))] public Vector3 to;
			[ShowIf(nameof(enabled))] public Ease ease = Ease.Linear;
			[ShowIf(nameof(enabled))] public float startDelay;
			[ShowIf(nameof(enabled))] public float duration;
			[ShowIf(nameof(enabled))] public RotateMode rotateMode;
		}

		[Serializable]
		public class ScaleAnimation {
			public bool enabled;
			[ShowIf(nameof(enabled))] public Vector3 from;
			[ShowIf(nameof(enabled))] public Vector3 to;
			[ShowIf(nameof(enabled))] public Ease ease = Ease.Linear;
			[ShowIf(nameof(enabled))] public float startDelay;
			[ShowIf(nameof(enabled))] public float duration;
		}
		

		[Serializable]
		public class FadeAnimation {
			public bool enabled;
			[ShowIf(nameof(enabled)), Range(0, 1)] public float from;
			[ShowIf(nameof(enabled)), Range(0, 1)] public float to;
			[ShowIf(nameof(enabled))] public Ease ease = Ease.Linear;
			[ShowIf(nameof(enabled))] public float startDelay;
			[ShowIf(nameof(enabled))] public float duration;
			[ShowIf(nameof(enabled))] public bool canvasEnabledDuringAnimation;
		}
	}
}