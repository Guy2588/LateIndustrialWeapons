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
    public class CompProperties_AmmoUser_WithAltGunshot : CompProperties_AmmoUser
    {
        public SoundDef normalSound;
        public SoundDef alternateSound;
        public List<AmmoDef> ammoDefsForAltSound;

        public CompProperties_AmmoUser_WithAltGunshot()
        {
            compClass = typeof(CompAmmoUser_WithAltGunshot);
        }
    }
}
