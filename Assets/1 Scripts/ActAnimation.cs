using UnityEngine;
using UnityEngine.UI;

public class ActAnimation : MonoBehaviour
{
    public string nombreAnimation;
    public Animator anim;
    public void ActAnimacion()
    {
        anim.SetBool(nombreAnimation,true);
    }
}
