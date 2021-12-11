using UnityEngine;

namespace UI.Component {
	[CreateAssetMenu(menuName = "Data/UI/Animation", fileName = "animation")]

	public partial class UIAnimation : ScriptableObject {

		[SerializeField] 
		private MoveAnimation move;
		public MoveAnimation Move => move;
		
		[SerializeField] 
		private RotateAnimation rotate;
		public RotateAnimation Rotate => rotate;
		
		[SerializeField] 
		private ScaleAnimation scale;
		public ScaleAnimation Scale => scale;
		
		[SerializeField] 
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