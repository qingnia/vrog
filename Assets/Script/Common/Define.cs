using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    dirUp, dirRight, dirDown, dirLeft, dirStop, dirNone,
}

public enum RetStatus
{
    rsSuccess, rsFail,
}

public enum PlayerStatus
{
    psEnter, psReady, psStart, psIngame, psDead,
}

public enum examType
{
    etSpeed, etStrength, etSpirit, etKnowledge,
    etPhysicalDamage, etMindDamage,
    etDice, etItem, //����ʹ����Ʒ
    etNone,
};