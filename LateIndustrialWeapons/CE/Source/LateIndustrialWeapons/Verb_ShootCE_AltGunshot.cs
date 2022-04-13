using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
//this code is only for when using with Combat Extended. If you're not using combat extended, this mod doesn't do anything intresting and just adds more generic guns
using CombatExtended;

namespace LateIndustrialWeapons
{
    class Verb_ShootCE_AltGunshot : Verb_ShootCE
    {
        //I wanted to have these variables all in one class, but I guess that's not possible to do with the way Rimworld is set up so I used comps and stuff instead.
        //public SoundDef normalSound;
        //public SoundDef alternateSound;
        //public List<AmmoDef> ammoDefsForAltSound;
        public CompAltGunshot compAltGunshot = null;

        //gets the comp from the thingDef
        public virtual CompAltGunshot CompAltGunshot
        {
            get
            {
                if (compAltGunshot == null && EquipmentSource != null) //getting a comp from a verb is easier than getting a verb from a comp, which I treid to do in "PatcherCodeBlurb" that I scrapped
                {
                    compAltGunshot = EquipmentSource.TryGetComp<CompAltGunshot>();
                }
                return compAltGunshot;
            }
        }

        //every time the gun begins to fire, check each ammoDef in the list of allowed ammoDefs that produce a different sound to see if they match with the ammoDef loaded in the gun
        //if it matches, switch the sound of the gun to the alternate one and reset it if none of them match
        public override void WarmupComplete() {
            if (CompAltGunshot != null) //null reference check, it requires the comp to get the list of ammoDefs that are allowed the alternate gunshot
            {
                foreach (AmmoDef ammoDef in CompAltGunshot.Props.ammoDefsForAltSound)
                {
                    if (ammoDef == compAmmo.CurrentAmmo && CompAltGunshot.Props.alternateSound != null)
                    {
                        base.verbProps.soundCast = CompAltGunshot.Props.alternateSound;
                        break;
                    }
                    else if (CompAltGunshot.Props.normalSound != null)
                    {
                        base.verbProps.soundCast = CompAltGunshot.Props.normalSound;
                    }
                }
            }
            //when the soundDef has been altered, the base function will run and call the altered sound to play
            base.WarmupComplete();
        }
    }
}
