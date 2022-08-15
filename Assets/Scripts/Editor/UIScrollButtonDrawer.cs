using UI.Component;
using UnityEditor;

[CustomEditor(typeof(UIScrollButton))]
public class UIScrollButtonDrawer : UISelectableDrawer {
	private SerializedProperty leftArrowProp;
	private SerializedProperty rightArrowProp;
	private SerializedProperty scaleDurationProp;
	private SerializedProperty scaleAmountProp;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		serializedObject.Update();
		leftArrowProp = serializedObject.FindProperty("leftArrow");
		rightArrowProp = serializedObject.FindProperty("rightArrow");
		scaleDurationProp = serializedObject.FindProperty("scaleDuration");
		scaleAmountProp = serializedObject.FindProperty("scaleAmount");
		
		EditorGUILayout.Space(20);
		
		EditorGUILayout.PropertyField(leftArrowProp);
		EditorGUILayout.PropertyField(rightArrowProp);
		EditorGUILayout.PropertyField(scaleDurationProp);
		EditorGUILayout.PropertyField(scaleAmountProp);
		serializedObject.ApplyModifiedProperties();
	}
}