using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;

namespace LateIndustrialWeapons
{
    public class harminy : Mod
    {
        //You might see the files CompAmmoUser_WithAltGunshot, CompProperties_AmmoUser_WithAltGunshot, and Verb_ShootCE_AltGunshot. Those were from previous tries to create the functionality of the mod.
        //I didn't like them, but there still there. They are not compiled.

        public harminy(ModContentPack content) : base(content)
        {

            //Calls harmony patches. Code is copy-pasted from somewhere since IDK how to set up harmony. You can copy-paste mine too, I don't mind.
            var harmony = new Harmony("Guy258.LateIndustrialWeapons");
            try
            {
                Log.Message("Late Industrial Weapons Harmony Patching...");
                harmony.PatchAll();

            }
            catch (Exception e)
            {
                Log.Error("(Late Industrial Weapons) Failed to apply 1 or more harmony patches! See error:");
                Log.Error(e.ToString());
            }
        }

    }
}