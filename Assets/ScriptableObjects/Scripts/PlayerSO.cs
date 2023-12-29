using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="Player", menuName ="Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 4f;
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; } 
}
