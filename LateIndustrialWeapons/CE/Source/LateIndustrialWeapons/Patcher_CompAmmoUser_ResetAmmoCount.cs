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
{
    //Enemies that spawn in with guns using charged ammo will automatically call my comp to change the sound
    //copy pasted code from PatcherCodeBlurb since it does the same thing, just at different situations
    [HarmonyPatch(typeof(CompAmmoUser), "ResetAmmoCount")]
    public static class Patcher_CompAmmoUser_ResetAmmoCount
    {
        [HarmonyPostfix]
        public static void ResetAmmoCount_ButWithAltGunshot(CompAmmoUser __instance)
        {
            CompAmmoUser compAmmoUser = __instance;
            if ((compAmmoUser.parent.GetComp<CompAltGunshot>() ?? null) != null)
            {
                compAmmoUser.parent.GetComp<CompAltGunshot>().ChangeSound(compAmmoUser.CurrentAmmo);
            }
        }
    }
}
