using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSetControl : MonoBehaviour {
    /*****************************
     *****SkillSetControl.cs******
     **スキルの動作のコントローラー**
     *****************************/
    [SerializeField]
    private List<string> names;//スキルの名前のリスト
    [SerializeField]
    private List<int> attackPowerss;//スキルの力
    [SerializeField]
    private List<GameObject> attackAnimations;//スキルのアニメーション
    [SerializeField]
    private List<int> requiredMP;//スキルの必要なマジックポイント
    [SerializeField]
    private List<bool> obtained;//スキルは知ったら、Trueになる
    [SerializeField]
    private int currentSelectedAttack;//決めたスキル。-2だったら、回復である。-1だったら、普通なあったく
    StatsControl statsControl;//プレイヤーのステータスのコントローラー
    [SerializeField]
    PinballVariablesControl pVarControl;//回復のオプションなら、ボールは増やす
    CursorMovementControl cursorControl;//選定のコントローラー
    private GameObject selectedEnemy;//アタックした敵
    private bool executingMove;//動作を行ったら、Trueになる。
    GameObject currentAnimation;//決めた動作のアニメーション
    [SerializeField]
    Camera mainCamera;//喧嘩のカメラ
    Rigidbody mainPlayerBallRB;//プレイヤーのボール
    SphereCollider mainPlayerBallBC;//プレイヤーのボールのコライダーのコンポネント


    public List<string> Names
    {
        get
        {
            return names;
        }

        set
        {
            names = value;
        }
    }
    public List<int> AttackPowerss
    {
        get
        {
            return attackPowerss;
        }

        set
        {
            attackPowerss = value;
        }
    }
    public List<GameObject> Animations
    {
        get
        {
            return attackAnimations;
        }

        set
        {
            attackAnimations = value;
        }
    }
    public List<int> RequiredMP
    {
        get
        {
            return requiredMP;
        }

        set
        {
            requiredMP = value;
        }
    }
    public List<bool> Obtained
    {
        get
        {
            return obtained;
        }

        set
        {
            obtained = value;
        }
    }
    public int CurrentSelectedAttack
    {
        get
        {
            return currentSelectedAttack;
        }

        set
        {
            currentSelectedAttack = value;
        }
    }
    public GameObject SelectedEnemy
    {
        get
        {
            return selectedEnemy;
        }

        set
        {
            selectedEnemy = value;
        }
    }
    public bool ExecutingMove
    {
        get
        {
            return executingMove;
        }

        set
        {
            executingMove = value;
        }
    }
    public GameObject CurrentAnimation
    {
        get
        {
            return currentAnimation;
        }

        set
        {
            currentAnimation = value;
        }
    }

    // Use this for initialization
    void Start () {
        currentSelectedAttack = -1;
        statsControl = GameObject.Find("StatsController").GetComponent<StatsControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ExecutingMove)
        {
            //カメラのバックグラウンドの色を変える
            if (mainCamera.backgroundColor.r < 0.5f)
            {
                mainCamera.backgroundColor = new Color(mainCamera.backgroundColor.r + 0.01f, mainCamera.backgroundColor.g, mainCamera.backgroundColor.b);
            }
            else
            {
                currentAnimation.transform.position = selectedEnemy.transform.position;
                CurrentAnimation.SetActive(true);
                if (mainPlayerBallRB == null)
                {
                    mainPlayerBallRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
                    mainPlayerBallBC = GameObject.Find("Ball").GetComponent<SphereCollider>();
                }
                mainPlayerBallRB.constraints = RigidbodyConstraints.FreezeAll;
                mainPlayerBallBC.enabled = false;
            }
            if (CurrentAnimation.GetComponent<AttackAnimationControl>().AnimationPlayed)
            {
                ExecutingMove = false;
                Destroy(CurrentAnimation);
                selectedEnemy = null;
                mainPlayerBallBC.enabled = true;
                mainPlayerBallRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            }
        }
        if (!ExecutingMove)
        {
            if (mainCamera.backgroundColor.r > 0)
            {
                mainCamera.backgroundColor = new Color(mainCamera.backgroundColor.r - 0.01f, mainCamera.backgroundColor.g, mainCamera.backgroundColor.b);
            }
        }
    }
    //ExecuteSkillMove関数
    //動作を行う
    public void ExecuteSkillMove()
    {
        if (currentSelectedAttack == -1 || (currentSelectedAttack==-2 && statsControl.Mp<20) || (currentSelectedAttack == -2 && pVarControl.NHP== pVarControl.MaxHP))//何も選んでなかったら、普通なアタックする。（スキルの動作を行わない）
        {
            return;
        }
        if (cursorControl == null)
        {
            cursorControl = GameObject.Find("CursorSelection").GetComponent<CursorMovementControl>();
        }
        if (currentSelectedAttack == -2)//回復のオプション
        {
            selectedEnemy = null;
            statsControl.Mp -= 20;
            //HP（ボール）を回復する
            pVarControl.NHP += 2;
            cursorControl.ResetCursorPosition();
        }
        if (currentSelectedAttack >= 0)//スキルアタックを行う
        {
            if (requiredMP[currentSelectedAttack] > statsControl.Mp)
            {
                return;
            }
            statsControl.Mp -= requiredMP[currentSelectedAttack];
            cursorControl.ResetCursorPosition();
            ExecutingMove = true;
            selectedEnemy.GetComponent<EnemyBumperControl>().DamageDealt = attackPowerss[currentSelectedAttack] + (int)(statsControl.Atk*1.2f);
            CurrentAnimation = Instantiate(attackAnimations[CurrentSelectedAttack], SelectedEnemy.transform.position, attackAnimations[CurrentSelectedAttack].transform.rotation);
            CurrentAnimation.SetActive(false);
        }
    }
}
