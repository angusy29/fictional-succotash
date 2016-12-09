using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {
	private bool hiding;
	static bool isSwinging;

	//private Animator animator;
	private Animation anim;

	// Use this for initialization
	void Start () {
		hiding = false;
		isSwinging = false;
		//animator = GetComponent<Animator> ();
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			// swing sword animation
			if (!hiding) {
				//animator.SetBool ("isAttack", true);
				anim.Play("SwingSword");
				isSwinging = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			// hiding the sword
			if (!hiding) {
				//animator.SetBool ("isHide", true);
				anim.Play("HideSword");
				hiding = true;
			} else {
				//animator.SetBool ("isShow", true);
				anim.Play("ShowSword");
				hiding = false;
			}
		}
	}

	void OnHideAnimationEnd() {
		hiding = true;
		//animator.SetBool ("isHide", false);
	}

	void OnShowAnimationEnd() {
		hiding = false;
		//animator.SetBool ("isShow", false);
	}

	void OnAttackAnimationEnd() {
		//animator.SetBool ("isAttack", false);
		isSwinging = false;
	}

	public static bool getIsSwinging() {
		return isSwinging;
	}
}
