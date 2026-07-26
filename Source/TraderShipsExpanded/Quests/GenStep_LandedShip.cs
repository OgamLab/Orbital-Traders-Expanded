using System.Linq;
using RimWorld;
using RimWorld.QuestGen;
using Verse;

namespace TraderShipsExpanded
{
    public class GenStep_LandedShip : GenStep
    {
        public override int SeedPart => 69696901;

        public override void Generate(Map map, GenStepParams parms)
        {
            Quest thisQuest = Utils.GetQuest(map);
            thisQuest.TryGetFirstPartOfType(out QuestPart_Hyperlinks hyperlinks);
            if (hyperlinks == null) Log.Error("no quest hyperlinks? what? why?");

            Pawn askerPawn = hyperlinks.pawns.FirstOrDefault();

            IntVec3 shipPos = IntVec3.Invalid;

            Thing ship = ThingMaker.MakeThing(Utils.GetRandomShipDef());
            int num = 2;
            while (!CellFinder.TryFindRandomCellNear(map.Center, map, num, (IntVec3 c) => Utils.CanPlaceAt(ship, map, c), out shipPos))
            {
                num++;
            }


            Faction faction = askerPawn.Faction;
            ship.SetFactionDirect(faction);

            var company = faction.def == TSE_DefOf.TSE_Faction_GTC ? TSE_DefOf.TSE_Company_GalaxyTrader : Utils.AllTraderCompanyDefs.Except(TSE_DefOf.TSE_Company_GalaxyTrader).RandomElement();

            Utils.TryCallInTraderShip(map, company, null, faction, true, false, shipPos, true); // spawns a ship directly instead of it flying in.
        }
    }
}