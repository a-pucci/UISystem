using UnityEngine;

namespace Utilities.Extensions {
	public static class Extensions {

		public static void Show(this CanvasGroup cg, bool value) {
			cg.alpha = value.ToInt();
			cg.interactable = value;
			cg.blocksRaycasts = value;
		}

		private static int ToInt(this bool value) => value ? 1 : 0;
	}
}