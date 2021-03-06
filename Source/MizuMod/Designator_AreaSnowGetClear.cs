﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using RimWorld;

namespace MizuMod
{
    public class Designator_AreaSnowGetClear : Designator_AreaSnowGet
    {
        public Designator_AreaSnowGetClear() : base(DesignateMode.Remove)
        {
            this.defaultLabel = MizuStrings.DesignatorAreaSnowGetClear.Translate();
            this.defaultDesc = MizuStrings.DesignatorAreaSnowGetClearDescription.Translate();
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/SnowClearAreaOff", true);
            this.soundDragSustain = SoundDefOf.Designate_DragAreaDelete;
            this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            this.soundSucceeded = SoundDefOf.Designate_AreaDelete;
        }
    }
}
