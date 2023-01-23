using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class SpaceEditor : EditorWindow
{
	private const string _asteroidVisualTreePath = "Assets/_Game/Scripts/Editor/SpaceEditorAsteroid.uxml";
	private const string _shipVisualTreePath = "Assets/_Game/Scripts/Editor/SpaceEditorShip.uxml";
	private const string _spawnerVisualTreePath = "Assets/_Game/Scripts/Editor/SpaceEditorSpawner.uxml";
	private const string _separatorVisualTreePath = "Assets/_Game/Scripts/Editor/Separator.uxml";

	private const string _asteroidConfigPath = "Assets/_Game/Components/Asteroid/AsteroidConfig.asset";
	private const string _shipConfigPath = "Assets/_Game/Components/Ship/ShipConfig.asset";


	[MenuItem("Window/UI Toolkit/SpaceEditor")]
	public static void ShowExample()
	{
		SpaceEditor wnd = GetWindow<SpaceEditor>();
		wnd.titleContent = new GUIContent("SpaceEditor");
	}

	public void CreateGUI()
	{
		// Each editor window contains a root VisualElement object
		VisualElement root = rootVisualElement;

		// Import UXML
		var spawnerElem = AddUXML(_spawnerVisualTreePath);
		AddUXML(_separatorVisualTreePath);
		var asteroidElem = AddUXML(_asteroidVisualTreePath);
		AddUXML(_separatorVisualTreePath);
		var shipElem = AddUXML(_shipVisualTreePath);

		var shipConfig = AssetDatabase.LoadAssetAtPath<ScriptableObject>(_shipConfigPath);

		var so = new SerializedObject(shipConfig);

		shipElem[0].Bind(so);
	}

	private VisualElement AddUXML(string path)
	{
		var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
		VisualElement dataFromUXML = visualTree.Instantiate();
		rootVisualElement.Add(dataFromUXML);
		return dataFromUXML;
	}
}