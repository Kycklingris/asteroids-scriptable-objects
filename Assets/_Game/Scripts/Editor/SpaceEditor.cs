using System.Collections.Generic;
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
		AddSpawnerTab();
		AddUXML(_separatorVisualTreePath);
		AddAsteroidTab();
		AddUXML(_separatorVisualTreePath);
		AddShipTab();

		ConnectSlidersAndFields();
	}

	private void ConnectSlidersAndFields()
	{
		var floatSliders = rootVisualElement.Query(name: "MinMaxSliderWithValueFloat").ToList();
		var intSliders = rootVisualElement.Query(name: "MinMaxSliderWithValueInt").ToList();

		foreach (var sliderWrapper in floatSliders)
		{
			var min = (FloatField)sliderWrapper[0];
			var slider = (MinMaxSlider)sliderWrapper[1];
			var max = (FloatField)sliderWrapper[2];

			slider.SetValueWithoutNotify(new Vector2(min.value, max.value));

			slider.RegisterValueChangedCallback<Vector2>((e) =>
			{
				min.value = e.newValue.x;
				max.value = e.newValue.y;
			});

			min.RegisterValueChangedCallback<float>((e) =>
			{
				if (e.newValue > max.value)
				{
					min.SetValueWithoutNotify(e.previousValue);
					e.PreventDefault();
					return;
				}

				var value = slider.value;
				value.x = e.newValue;

				slider.SetValueWithoutNotify(value);
			});

			max.RegisterValueChangedCallback<float>((e) =>
			{
				if (e.newValue < min.value)
				{
					max.SetValueWithoutNotify(e.previousValue);
					e.PreventDefault();
					return;
				}

				var value = slider.value;
				value.y = e.newValue;

				slider.SetValueWithoutNotify(value);
			});
		}

		foreach (var sliderWrapper in intSliders)
		{
			var min = (IntegerField)sliderWrapper[0];
			var slider = (MinMaxSlider)sliderWrapper[1];
			var max = (IntegerField)sliderWrapper[2];

			slider.SetValueWithoutNotify(new Vector2(min.value, max.value));

			slider.RegisterValueChangedCallback<Vector2>((e) =>
			{
				min.value = (int)e.newValue.x;
				max.value = (int)e.newValue.y;
			});

			min.RegisterValueChangedCallback<int>((e) =>
			{
				if (e.newValue > max.value)
				{
					min.SetValueWithoutNotify(e.previousValue);
					e.PreventDefault();
					return;
				}

				var value = slider.value;
				value.x = e.newValue;

				slider.SetValueWithoutNotify(value);
			});

			max.RegisterValueChangedCallback<int>((e) =>
			{
				if (e.newValue < min.value)
				{
					max.SetValueWithoutNotify(e.previousValue);
					e.PreventDefault();
					return;
				}

				var value = slider.value;
				value.y = e.newValue;

				slider.SetValueWithoutNotify(value);
			});
		}
	}

	private void AddSpawnerTab()
	{
		var asteroidConfig = AssetDatabase.LoadAssetAtPath<ScriptableObject>(_asteroidConfigPath);
		var asteroidSO = new SerializedObject(asteroidConfig);

		var spawnerElem = AddUXML(_spawnerVisualTreePath);
		spawnerElem[0].Bind(asteroidSO);
	}

	private void AddAsteroidTab()
	{
		var shipConfig = AssetDatabase.LoadAssetAtPath<ScriptableObject>(_shipConfigPath);
		var shipSO = new SerializedObject(shipConfig);

		var asteroidConfig = AssetDatabase.LoadAssetAtPath<ScriptableObject>(_asteroidConfigPath);
		var asteroidSO = new SerializedObject(asteroidConfig);

		var asteroidElem = AddUXML(_asteroidVisualTreePath);
		asteroidElem[0].Bind(asteroidSO);
		asteroidElem[0].Bind(shipSO);
	}
	private void AddShipTab()
	{
		var shipConfig = AssetDatabase.LoadAssetAtPath<ScriptableObject>(_shipConfigPath);
		var shipSO = new SerializedObject(shipConfig);

		var shipElem = AddUXML(_shipVisualTreePath);
		shipElem[0].Bind(shipSO);
	}

	private VisualElement AddUXML(string path)
	{
		var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
		VisualElement dataFromUXML = visualTree.Instantiate();
		rootVisualElement.Add(dataFromUXML);
		return dataFromUXML;
	}
}