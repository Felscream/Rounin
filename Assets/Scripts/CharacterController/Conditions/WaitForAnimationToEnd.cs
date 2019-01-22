using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/WaitForAnimationToEnd")]
    public class WaitForAnimationToEnd : Condition
    {
        public string TargetBool = "IsInteracting";

        public override bool CheckCondition(StateManager     state)
        {
            bool value = !state.Animator.GetBool(TargetBool);
            return value;
        }
    }
}

