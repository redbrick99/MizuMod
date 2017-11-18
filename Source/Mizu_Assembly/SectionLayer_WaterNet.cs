﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace MizuMod
{
    internal class SectionLayer_WaterNet : SectionLayer_Things
    {
        public SectionLayer_WaterNet(Section section) : base(section)
		{
            this.requireAddToMapMesh = false;
            this.relevantChangeTypes = MapMeshFlag.Buildings;
        }

        public override void DrawLayer()
        {
            Designator_Build designator_Build = Find.DesignatorManager.SelectedDesignator as Designator_Build;
            if (designator_Build != null)
            {
                ThingDef thingDef = designator_Build.PlacingDef as ThingDef;
                CompProperties_WaterNet compprops = thingDef.GetCompProperties<CompProperties_WaterNet>();
                if (thingDef != null && compprops != null)
                {
                    base.DrawLayer();
                }
            }
        }

        protected override void TakePrintFrom(Thing t)
        {
            IBuilding_WaterNet building = t as IBuilding_WaterNet;
            if (building != null)
            {
                building.PrintForGrid(this);
            }
        }
    }
}
