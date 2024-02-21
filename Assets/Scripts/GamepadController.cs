using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadController : Singleton<GamepadController>
{
    public bool isOnMobile;
    private bool canMoveLeft;
    private bool canMoveRight;

    public bool CanMoveLeft { get => canMoveLeft; set => canMoveLeft = value; }
    public bool CanMoveRight { get => canMoveRight; set => canMoveRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }   

    private void PCInputHandle()
    {
        if (isOnMobile) return;

        canMoveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        canMoveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }

    private void Update()
    {
        PCInputHandle();
    }
}
