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
    //sets up the fields that you see in the XML and links them to my new comp
    public class CompProperties_AltGunshot : CompProperties
    {
        public SoundDef normalSound;
        public SoundDef alternateSound;
        public List<AmmoDef> ammoDefsForAltSound;

        public CompProperties_AltGunshot()
        {
            compClass = typeof(CompAltGunshot);
        }
    }
}
