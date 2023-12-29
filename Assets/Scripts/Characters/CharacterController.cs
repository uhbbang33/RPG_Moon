using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<PlayerAttackData> OnAttackEvent;

    //private Player _player;

    private void Start()
    {
        //_player = GetComponent<Player>();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector3 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(PlayerAttackData attackData)
    {
        OnAttackEvent?.Invoke(attackData);
    }
}
