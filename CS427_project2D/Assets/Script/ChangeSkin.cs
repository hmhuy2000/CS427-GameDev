using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController roseAnim;
    public AnimatorOverrideController snowAnim;

    public void changeRoseSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = roseAnim as RuntimeAnimatorController;
    }

    public void changeSnowSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = snowAnim as RuntimeAnimatorController;
    }


}
