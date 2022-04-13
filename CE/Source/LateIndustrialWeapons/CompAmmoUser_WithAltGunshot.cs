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
    public class CompAmmoUser_WithAltGunshot : CompAmmoUser
    {
        public CompProperties_AmmoUser_WithAltGunshot Properties
        {
            get
            {
                return (CompProperties_AmmoUser_WithAltGunshot)props;
            }
        }
    }
}
