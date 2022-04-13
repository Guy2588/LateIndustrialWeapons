using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using CombatExtended;
using HarmonyLib;

namespace LateIndustrialWeapons
    //I would change the name to match the naming sceme of the others, but it's a hastle so I'll leave it like this.
{
    [HarmonyPatch(typeof(CompAmmoUser), "LoadAmmo")]
    public static class PatcherCodeBlurb //Patcher_CompAmmoUser_LoadAmmo
    {
        //This code bit runs after Combat Extended's LoadAmmo method of CompAmmoUser
        [HarmonyPostfix]
        public static void LoadAmmo_ButWithAltGunshot(CompAmmoUser __instance) {
            //Tells my new comp (CompAltGunshot) to change the sound every time the gun is reloaded if my comp exists.
            CompAmmoUser compAmmoUser = __instance;
            if ((compAmmoUser.parent.GetComp<CompAltGunshot>() ?? null) != null) {
                compAmmoUser.parent.GetComp<CompAltGunshot>().ChangeSound(compAmmoUser.CurrentAmmo);
            }
        }
    }
}
