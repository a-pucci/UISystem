using UI.Component;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIAnimation))]
public class UIAnimationDrawer : Editor {
	private static Color MoveColor => Color.green;
	private static Color RotateColor => Color.magenta;
	private static Color ScaleColor => Color.cyan;
	private static Color FadeColor => Color.yellow;

	public override void OnInspectorGUI() {
		serializedObject.Update();
		SerializedProperty moveProp = serializedObject.FindProperty("move");
		SerializedProperty rotateProp = serializedObject.FindProperty("rotate");
		SerializedProperty scaleProp = serializedObject.FindProperty("scale");
		SerializedProperty fadeProp = serializedObject.FindProperty("fade");
		
		Color color = GUI.backgroundColor;

		GUI.backgroundColor = MoveColor;
		DrawMove(ref moveProp);
		GUI.backgroundColor = color;

		DrawLine();
		GUI.backgroundColor = RotateColor;
		DrawRotate(ref rotateProp);
		GUI.backgroundColor = color;

		DrawLine();
		GUI.backgroundColor = ScaleColor;
		DrawScale(ref scaleProp);
		GUI.backgroundColor = color;
		
		DrawLine();
		GUI.backgroundColor = FadeColor;
		DrawFade(ref fadeProp);
		GUI.backgroundColor = color;
		
		serializedObject.ApplyModifiedProperties();
	}

	private void DrawMove(ref SerializedProperty prop) {
		SerializedProperty enabledProp = prop.FindPropertyRelative("enabled");
		SerializedProperty fromProp = prop.FindPropertyRelative("from");
		SerializedProperty toProp = prop.FindPropertyRelative("to");
		SerializedProperty easeProp = prop.FindPropertyRelative("ease");
		SerializedProperty delayProp = prop.FindPropertyRelative("startDelay");
		SerializedProperty durationProp = prop.FindPropertyRelative("duration");

		EditorGUILayout.PropertyField(enabledProp, new GUIContent("Move", "Enable movement animation"));

		if (!enabledProp.boolValue)
			return;

		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(fromProp, new GUIContent("From", "Starting Rect position"));
		EditorGUILayout.PropertyField(toProp, new GUIContent("To", "Ending Rect position"));
		EditorGUILayout.PropertyField(easeProp, new GUIContent("Ease", "Value interpolation curve type"));
		EditorGUILayout.PropertyField(delayProp, new GUIContent("Start Delay", "Animation starting delay"));
		EditorGUILayout.PropertyField(durationProp, new GUIContent("Duration", "Animation duration"));
		EditorGUI.indentLevel--;
	}

	private void DrawRotate(ref SerializedProperty prop) {
		SerializedProperty enabledProp = prop.FindPropertyRelative("enabled");
		SerializedProperty fromProp = prop.FindPropertyRelative("from");
		SerializedProperty toProp = prop.FindPropertyRelative("to");
		SerializedProperty easeProp = prop.FindPropertyRelative("ease");
		SerializedProperty delayProp = prop.FindPropertyRelative("startDelay");
		SerializedProperty durationProp = prop.FindPropertyRelative("duration");
		SerializedProperty rotateModeProp = prop.FindPropertyRelative("rotateMode");

		EditorGUILayout.PropertyField(enabledProp, new GUIContent("Rotate", "Enable Rotation animation"));

		if (!enabledProp.boolValue)
			return;
		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(fromProp, new GUIContent("From", "Starting Rotation value"));
		EditorGUILayout.PropertyField(toProp, new GUIContent("To", "Ending Rotation value"));
		EditorGUILayout.PropertyField(easeProp, new GUIContent("Ease", "Value interpolation curve type"));
		EditorGUILayout.PropertyField(delayProp, new GUIContent("Start Delay", "Animation starting delay"));
		EditorGUILayout.PropertyField(durationProp, new GUIContent("Duration", "Animation duration"));
		EditorGUILayout.PropertyField(rotateModeProp, new GUIContent("Rotate Mode", "Rotation type"));
		EditorGUI.indentLevel--;
	}

	private void DrawScale(ref SerializedProperty prop) {
		SerializedProperty enabledProp = prop.FindPropertyRelative("enabled");
		SerializedProperty fromProp = prop.FindPropertyRelative("from");
		SerializedProperty toProp = prop.FindPropertyRelative("to");
		SerializedProperty easeProp = prop.FindPropertyRelative("ease");
		SerializedProperty delayProp = prop.FindPropertyRelative("startDelay");
		SerializedProperty durationProp = prop.FindPropertyRelative("duration");

		EditorGUILayout.PropertyField(enabledProp, new GUIContent("Scale", "Enable Scale animation"));

		if (!enabledProp.boolValue)
			return;

		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(fromProp, new GUIContent("From", "Starting Scale value"));
		EditorGUILayout.PropertyField(toProp, new GUIContent("To", "Ending Scale value"));
		EditorGUILayout.PropertyField(easeProp, new GUIContent("Ease", "Value interpolation curve type"));
		EditorGUILayout.PropertyField(delayProp, new GUIContent("Start Delay", "Animation starting delay"));
		EditorGUILayout.PropertyField(durationProp, new GUIContent("Duration", "Animation duration"));
		EditorGUI.indentLevel--;
	}
	
	private void DrawFade(ref SerializedProperty prop) {
		SerializedProperty enabledProp = prop.FindPropertyRelative("enabled");
		SerializedProperty fromProp = prop.FindPropertyRelative("from");
		SerializedProperty toProp = prop.FindPropertyRelative("to");
		SerializedProperty easeProp = prop.FindPropertyRelative("ease");
		SerializedProperty delayProp = prop.FindPropertyRelative("startDelay");
		SerializedProperty durationProp = prop.FindPropertyRelative("duration");
		SerializedProperty canvasEnabledProp = prop.FindPropertyRelative("canvasEnabledDuringAnimation");

		EditorGUILayout.PropertyField(enabledProp, new GUIContent("Fade", "Enable Fade animation"));

		if (!enabledProp.boolValue)
			return;

		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(fromProp, new GUIContent("From", "Starting CanvasGroup alpha value"));
		EditorGUILayout.PropertyField(toProp, new GUIContent("To", "Ending CanvasGroup alpha value"));
		EditorGUILayout.PropertyField(easeProp, new GUIContent("Ease", "Value interpolation curve type"));
		EditorGUILayout.PropertyField(delayProp, new GUIContent("Start Delay", "Animation starting delay"));
		EditorGUILayout.PropertyField(durationProp, new GUIContent("Duration", "Animation duration"));
		EditorGUILayout.PropertyField(canvasEnabledProp, new GUIContent("Canvas Enabled", "Enable/Disable canvas during animation"));
		EditorGUI.indentLevel--;
	}

	private void DrawLine() {
		EditorGUI.indentLevel--;
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		EditorGUI.indentLevel++;
	}
}