using System;
using NaughtyAttributes;
using UnityEngine;

namespace UI.Component {
	[CreateAssetMenu(menuName = "Data/UI/Component Settings", fileName = "component_settings")]
	public class UIComponentSettings : ScriptableObject {
		[Serializable]
		public struct Blink {
			[Header("Blink settings")] 
			public int confirmFlashes;
			public float confirmFlashTime;
	
			[Header("Error settings")]
			public float errorFlashTime;
		}
		
		[Serializable]
		public struct Colors {
			public Color label;
			public Color fill;
			public Color border;
		}

		[Serializable]
		public struct EventAnimations {
			public UIAnimation selectAnimation; 
			public UIAnimation deselectAnimation; 
			public UIAnimation confirmAnimation; 
			public UIAnimation errorAnimation;
		}

		[SerializeField, BoxGroup("Colors")]
		private Colors pressed = default;
		public Colors Pressed => pressed;
		
		[SerializeField, BoxGroup("Colors")]
		private Colors unpressed = default;
		public Colors Unpressed => unpressed;
		
		[SerializeField, BoxGroup("Colors")]
		private Colors selected = default;
		public Colors Selected => selected;
		
		[SerializeField, BoxGroup("Colors")]
		private Colors error = default;
		public Colors Error => error;

		[BoxGroup("Settings"),SerializeField, Label("")] 
		private Blink blinkSettings = default;
		public Blink BlinkSettings => blinkSettings;
		
		[BoxGroup("Animations"),SerializeField, Label("")] 
		private EventAnimations eventAnimations = default;
		public EventAnimations Animations => eventAnimations;
	}
}