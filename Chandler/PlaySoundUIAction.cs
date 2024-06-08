using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PYMN4
{
    public class PlaySoundUIAction : CombatAction
    {
        public string Audio;
        public Vector3 Location;
        public PlaySoundUIAction(string audio, Vector3 loc)
        {
            Audio = audio;
            Location = loc;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            RuntimeManager.PlayOneShot(Audio, Location);
            yield return null;
        }
    }
}
