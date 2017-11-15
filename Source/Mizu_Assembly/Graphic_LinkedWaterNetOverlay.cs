﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;

namespace MizuMod
{
    public class Graphic_LinkedWaterNetOverlay : Graphic_Linked
    {
        public Graphic_LinkedWaterNetOverlay() : base()
        {
            
        }

        public Graphic_LinkedWaterNetOverlay(Graphic subGraphic) : base(subGraphic)
        {

        }

        public override bool ShouldLinkWith(IntVec3 c, Thing parent)
        {
            IBuilding_WaterNetBase thing_wnb = parent as IBuilding_WaterNetBase;
            if (thing_wnb == null || !thing_wnb.IsActivatedForWaterNet || !thing_wnb.ConnectVecs.Contains(c))
            {
                return false;
            }

            ThingWithComps thing = parent as ThingWithComps;
            CompWaterNetBase comp = thing.GetComp<CompWaterNetBase>();
            bool isFound = false;
            foreach (var net in comp.Manager.Nets)
            {
                foreach (var t in net.Things)
                {
                    IBuilding_WaterNetBase t_wnb = t as IBuilding_WaterNetBase;
                    if (t_wnb == null || !t_wnb.IsActivatedForWaterNet)
                    {
                        continue;
                    }

                    if (t == thing)
                    {
                        if (t.OccupiedRect().Contains(c))
                        {
                            isFound = true;
                            goto LinkFound;
                        }
                    }
                    else
                    {
                        if (t.OccupiedRect().Contains(c) && t.IsConnectedTo(thing))
                        {
                            isFound = true;
                            goto LinkFound;
                        }
                    }
                }
            }

        LinkFound:
            return GenGrid.InBounds(c, parent.Map) && isFound;
        }

        public override void Print(SectionLayer layer, Thing parent)
        {
            foreach (var current in parent.OccupiedRect())
            {
                Vector3 vector = current.ToVector3ShiftedWithAltitude(AltitudeLayer.WorldDataOverlay);
                Printer_Plane.PrintPlane(layer, vector, Vector2.one, base.LinkedDrawMatFrom(parent, current), 0f, false, null, null, 0.01f);
            }
        }
    }
}
