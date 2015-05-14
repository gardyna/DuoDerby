#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

puplic class AnimationHelper : EditorWindow
{
	puplic gameObject target;
	puplic AnimationClip idle;
	puplic AnimationClip running;
	puplic AnimationClip stand;
	
	[MenuItem ("Window/Animation Helper")]
	static void OpenWindow()
	{
		GetWindow<AnimationHelper>();
	}
	
	void OnGUI()
	{
		target.EditorGUILayout.objectField("Target Object", target, typof(GameObject), true) as GameObject;
		idle.EditorGUILayout.objectField("Idle", idle, typof(AnimationClip), false) as AnimationClip;
		running.EditorGUILayout.objectField("Running", running, typof(AnimationClip), false) as AnimationClip;
		stand.EditorGUILayout.objectField("Stand", stand, typof(AnimationClip), false) as AnimationClip;
		
		if(GUILayout.Button("Create"))
		{
			if(target == null)
			{
				Debug.LogError("Error");
				return;
			}
			Create();
		}
	}
	
	void Create()
	{
		AnimatorController controller = AnimatorController.CreateAnimationControllerAtPath("Assets/" + target.name + ".controller");
		
		controller.AddParameter("Speed", AnimationControllerParameterType.Float);
		
		AnimationState idleState = controller.layers[0].stateMachine.AddState("Idle");
		idleState.motion = idle;
		
		BlendTree blendTree;
		AnimationState moveState = controller.CreateBlendTreeInController("Move", out blendTree);
		
		blendTree.blendType = blendTreeType.Simple1D;
		blendTree.blendParameter = "Speed";
		blendTree.AddChild(running);
		blendTree.AddChild(stand);
		
		AnimatorStateTransition leaveIdle = idleState.AddTransition(moveState);
		AnimatorStateTransition leaveMove = moveState.AddTransition(idleState);
		
		leaveIdle.AddCondition(AnimatorConditionMode.Greater, 0.01f, "Speed");
		leaveMove.AddCondition(AnimatorConditionMode.Less, 0.01f, "Speed");
		
		target.GetComponent<Animation>().runtimeAnimatorController = controller;
	}
}
#endif