using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    private bool _isTrapActive = false;

    protected override void KillPlayer(IPlayer player)
    {
        if (_isTrapActive)
        {
            base.KillPlayer(player);
        }
    }

    public override void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            _isTrapActive = true;
        }
    }
}
