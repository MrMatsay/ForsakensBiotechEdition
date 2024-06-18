using System;
using System.Text;
using RimWorld;
using Verse;

namespace ForsakenBiotech
{
    public class Ultraviolett : Plant
    {
        public override float GrowthRate => base.GrowthRateFactor_Fertility * base.GrowthRateFactor_Light;

        protected override void CheckMakeLeafless()
        {
        }
		public override string GetInspectString()
		{
			StringBuilder stringBuilder = new StringBuilder();
            if (this.def.plant.showGrowthInInspectPane)
			{
                if (this.LifeStage == PlantLifeStage.Growing)
				{
					stringBuilder.AppendLine("PercentGrowth".Translate(base.GrowthPercentString));
					stringBuilder.AppendLine("GrowthRate".Translate() + ": " + this.GrowthRate.ToStringPercent());
                    if (!base.Blighted)
					{
                        if (this.Resting)
						{
							stringBuilder.AppendLine("PlantResting".Translate());
						}
                        if (!this.HasEnoughLightToGrow)
						{
							stringBuilder.AppendLine("PlantNeedsLightLevel".Translate() + ": " + this.def.plant.growMinGlow.ToStringPercent());
						}
					}
				}
				else
				{
                    if (this.LifeStage == PlantLifeStage.Mature)
					{
                        if (this.HarvestableNow)
						{
							stringBuilder.AppendLine("ReadyToHarvest".Translate());
						}
						else
						{
							stringBuilder.AppendLine("Mature".Translate());
						}
					}
				}
                if (this.DyingBecauseExposedToLight)
				{
					stringBuilder.AppendLine("DyingBecauseExposedToLight".Translate());
				}
                if (base.Blighted)
				{
					stringBuilder.AppendLine("Blighted".Translate() + " (" + base.Blight.Severity.ToStringPercent() + ")");
				}
			}
			string text = base.InspectStringPartsFromComps();
            if (!text.NullOrEmpty())
			{
				stringBuilder.Append(text);
			}
			return stringBuilder.ToString().TrimEndNewlines();
		}
	}
}
