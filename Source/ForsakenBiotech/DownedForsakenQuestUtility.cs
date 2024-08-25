using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ForsakenBiotech
{
    public static class DownedForsakenQuestUtility
    {
        public static Faction GetForsakensFaction()
        {
            List<Faction> list = (from t in Find.FactionManager.AllFactions
                                  where t.def.defName == "Forsakens"
                                  select t).ToList<Faction>();
            int index = new Random().Next(list.Count);
            return list[index];
        }
        public static Pawn GenerateRefugee()
        {
            if (!(DownedForsakenQuestUtility.GetForsakensFaction() is Faction forsakensFaction))
            {
                return null;
            }
            else
            {
                Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(DefDatabase<PawnKindDef>.GetNamed("Town_GuardF", true), forsakensFaction, PawnGenerationContext.NonPlayer, -1, false, false, false, true, false, 1f, false, true, false, true, true, false, false, false, false, 0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null, 0f, DevelopmentalStage.Adult, null, null, null, false, false, false, -1, 0, false));
                HealthUtility.DamageUntilDowned(pawn, false, null, null, null);
                HealthUtility.DamageLegsUntilIncapableOfMoving(pawn, false);
                return pawn;
            }
        }
    }
}
