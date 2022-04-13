using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using CombatExtended;

namespace LateIndustrialWeapons
{
    public class CompAltGunshot : ThingComp
    {
        //the main component of my mod's code
        //links the CompProperties with the Comp (I think it does, I'm not really an expert so I just copy-pasted this line too)
        public CompProperties_AltGunshot Props => (CompProperties_AltGunshot)props;

        //Changes the sound of the gun if the ammo in the gun is one of the ammo types in the list that needs to have a different gunshot sound
        public void ChangeSound(AmmoDef CurrentAmmo) {
            //goes thorugh each ammoDef in the list
            foreach (AmmoDef ammoDef in Props.ammoDefsForAltSound)
            {
                if (ammoDef == CurrentAmmo && Props.alternateSound != null)
                {
                    this.parent.def.Verbs.Find(VerbProperties => VerbProperties.verbClass == typeof(Verb_ShootCE)).soundCast = Props.alternateSound;
                    //Log.Message("Match " + CurrentAmmo + " as " + ammoDef + " and changing sound.");
                    break;
                }
                else if (Props.normalSound != null)
                {
                    this.parent.def.Verbs.Find(VerbProperties => VerbProperties.verbClass == typeof(Verb_ShootCE)).soundCast = Props.normalSound;
                    //Log.Message("No match, " + CurrentAmmo + " is not " + ammoDef + " and reverting sound.");
                }
            }
        }
        //When loading up your save
        //Otherwise, if you log out and the gun has charged ammo in it, then when you go back in, the gun will revert to the standard sound and mess up the other components of the mod.
        public override void PostExposeData()
        {
            //didn't override the initialize function because when that calls, CompAmmoUser also hasn't been initialized so I can't get the CurrentAmmo
            base.PostExposeData();
            if ((this.parent.GetComp<CompAmmoUser>() ?? null) != null) //fancy notation I copied which basically returns if CompAmmoUser exists
            {
                ChangeSound(this.parent.GetComp<CompAmmoUser>().CurrentAmmo);
            }
            else
            {
                Log.Error("CompAmmoUser does not exist yet.");
            }
        }
    }
}
