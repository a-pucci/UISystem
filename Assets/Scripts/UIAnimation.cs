using NaughtyAttributes;
using UnityEngine;

namespace UI.Component {
	[CreateAssetMenu(menuName = "Data/UI/Animation", fileName = "animation")]

	public partial class UIAnimation : ScriptableObject {

		[SerializeField, HorizontalLine(color: EColor.Green)] 
		private MoveAnimation move;
		public MoveAnimation Move => move;
		
		[SerializeField, HorizontalLine(color: EColor.Violet)] 
		private RotateAnimation rotate;
		public RotateAnimation Rotate => rotate;
		
		[SerializeField, HorizontalLine(color: EColor.Orange)] 
		private ScaleAnimation scale;
		public ScaleAnimation Scale => scale;
		
		[SerializeField, HorizontalLine(color: EColor.Yellow)] 
		private FadeAnimation fade;
		public FadeAnimation Fade => fade;
		
		public float TotalDuration =>
			Mathf.Max(Move.enabled ? Move.startDelay : 0,
				Rotate.enabled ? Rotate.startDelay : 0,
				Scale.enabled ? Scale.startDelay : 0,
				Fade.enabled ? Fade.startDelay : 0)
			+
			Mathf.Max(Move.enabled ? Move.duration : 0,
				Rotate.enabled ? Rotate.duration : 0,
				Scale.enabled ? Scale.duration : 0,
				Fade.enabled ? Fade.duration : 0);
	}
}