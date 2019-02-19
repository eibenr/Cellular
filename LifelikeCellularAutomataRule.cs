using System;

namespace Cellular {

	/*
	B0123478/S01234678	AntiLife	
	B012345678/S34678	InverseLife	
	B1/S012345678		H-trees	
	B1/S1				Gnarl	A simple exploding rule that forms complex patterns from even a single live cell.
	B1357/S02468		Fredkin	A rule in which, like Replicator, every pattern is a replicator. Also known as "Replicator 2".
	B1357/S1357			Replicator	A rule in which every pattern is a replicator.
	B2/S				Seeds	An exploding rule in which every cell dies in every generation. It has many simple orthogonal spaceships, though it is in general difficult to create patterns that don't explode.
	B2/S0				Live Free or Die	An exploding rule in which only cells with no neighbors survive. It has many spaceships, puffers, and oscillators, some of infinitely extensible size and period.
	B234/S				Serviettes	An exploding rule in which every cell dies every generation (like seeds). This rule is of interest because of the fabric-like beauty of the patterns that it produces. Also known as "Persian Rug".
	B25678/S5678		Iceballs	
	B3/S012345678		Life without death	An expanding rule that produces complex flakes. It also has important ladder patterns. Also known as "Flakes" or "Inkspot".
	B3/S023				DotLife	An exploding rule closely related to Conway's Life. The B-heptomino is a common infinite growth pattern in this rule, though it can be stabilized into a spaceship.
	B3/S12				Flock	Patterns tend to quickly settle into dominos, duoplets and period 2 oscillators. There is a common period 14 shuttle oscillator involving the pre-beehive.
	B3/S1234			Mazectric	An expanding rule that crystalizes to form maze-like designs that tend to be straighter (ie. have longer "halls") than the standard maze rule.
	B3/S12345			Maze	An expanding rule that crystalizes to form maze-like designs.
	B3/S1237			SnowLife	
	B3/S124				Corrosion of Conformity	
	B3/S13				LowLife	
	B3/S23				Conway's Life	A chaotic rule that is by far the most well-known and well-studied. It exhibits highly complex behavior.
	B3/S238				EightLife	Also known as "Pulsar Life".
	B3/S45678			Coral	An exploding rule in which patterns grow slowly and form coral-like textures.
	B34/S34				34 Life	An exploding rule that was initially thought to be a stable alternative to Conway's Life, until computer simulation found that most patterns tend to explode. It has many small oscillators and simple period 3 orthogonal and diagonal spaceships.
	B34/S456			Bacteria	
	B345/S2				Blinkers	
	B345/S4567			Assimilation	A very stable rule that forms permanent diamond-shaped patterns with partially filled interiors.
	B345/S5				Long Life	A stable rule that gets its name from the fact that it has many simple extremely high period oscillators.
	B3457/S4568			Gems	An exploding rule with many smaller high-period oscillators and a c/5648 spaceship.
	B34578/S456			Gems Minor	An exploding rule with many smaller high-period oscillators and a c/2068 spaceship.
	B35/S234578			Land Rush	
	B3567/S15678		Bugs	
	B35678/S4678		Holstein	
	B35678/S5678		Diamoeba	A chaotic pattern that forms large diamonds with chaotically oscillating boundaries. Known to have quadratically-growing patterns.
	B357/S1358			Amoeba	A chaotic rule that is well balanced between life and death; it forms patterns with chaotic interiors and wildly moving boundaries.
	B357/S238			Pseudo Life	A chaotic rule with evolution that resembles Conway's Life, but few patterns from Life work in this rule because the glider is unstable.
	B36/S125			2x2	A chaotic rule with many simple still lifes, oscillators and spaceships. Its name comes from the fact that it sends patterns made up of 2x2 blocks to patterns made up of 2x2 blocks.
	B36/S235			Blinker Life	An exploding rule where the T-tetromino is a blinker puffer, appropriate because it evolves into traffic light in Life, also made of blinkers.
	B36/S23				HighLife	A chaotic rule very similar to Conway's Life that is of interest because it has a simple replicator.
	B367/S125678		Slow Blob	
	B3678/S235678		Stains	A stable rule in which most patterns tend to "fill in" bounded regions. Most nearby rules (such as coagulations) tend to explode.
	B3678/S34678		Day & Night	A stable rule that is symmetric under on-off reversal. Many patterns exhibiting highly complex behavior have been found for it.
	B368/S238			LowDeath	HighLife's replicator works in this rule, albeit with a different evolution sequence due to the result of B38/S23's pedestrian effect.
	B368/S245			Move	A rule in which random patterns tend to stabilize extremely quickly. Has a very common slow-moving spaceship and slow-moving puffer. Also known as "Morley".
	B37/S1234			Mazectric with Mice	
	B37/S12345			Maze with Mice	
	B37/S23				DryLife	An exploding rule closely related to Conway's Life, named after the fact that the standard spaceships bigger than the glider do not function in the rule. Has a small puffer based on the R-pentomino, which resembles the switch engine in the possibility of combining several to form a spaceship.
	B378/S012345678		Plow World	
	B378/S235678		Coagulations	An exploding rule in which patterns tend to expand forever, producing a thick "goo" as it does so. Suprisingly, Coagulations actually has one less birth condition than Stains.
	B38/S23				Pedestrian Life	Has a number of natural elementary (5,2)c/190 knightships.
	B38/S238			HoneyLife	
	B45/S12345			Electrified Maze	
	B45678/S2345		Walled cities	A stable rule that forms centers of pseudo-random activity separated by walls.
	B4678/S35678		Vote 4/5	A modification of the standard Gérard Vichniac voting rule, also known as "Anneal", used as a model for majority voting.
	B5678/S45678		Vote	Standard Gérard Vichniac voting rule, also known as "Majority", used as a model for majority voting. 
	*/
	public class LifelikeCellularAutomataRule : ICellularAutomataRule {

		public CellularAutomataNeighborhoodType NeighborhoodType { get { return CellularAutomataNeighborhoodType.Moore; } }

		public const string AmoebaLifeRule = "B357/S1358";
		public const string AntiLifeRule = "B0123478/S01234678";
		public const string AssimilationLifeRule = "B345/S4567";
		public const string BacteriaLifeRule = "B34/S456";
		public const string BlinkerLifeRule = "B36/S235";
		public const string BlinkersLifeRule = "B345/S2";
		public const string BugsLifeRule = "B3567/S15678";
		public const string CoagulationsLifeRule = "B378/S235678";
		public const string ConwaysLifeRule = "B3/S23";
		public const string CoralLifeRule = "B3/S45678";
		public const string CorrosionOfConformityLifeRule = "B3/S124";
		public const string DayAndNightLifeRule = "B3678/S34678";
		public const string DiamoebaLifeRule = "B35678/S5678";
		public const string DotLifeRule = "B3/S023";
		public const string DryLifeRule = "B37/S23";
		public const string EightLifeRule = "B3/S238";
		public const string ElectrifiedMazeLifeRule = "B45/S12345";
		public const string FlockLifeRule = "B3/S12";
		public const string FredkinLifeRule = "B1357/S02468";
		public const string GemsLifeRule = "B3457/S4568";
		public const string GemsMinorLifeRule = "B34578/S456";
		public const string GnarlLifeRule = "B1/S1";
		public const string HighLifeRule = "B36/S23";
		public const string HolsteinLifeRule = "B35678/S4678";
		public const string HoneyLifeRule = "B38/S238";
		public const string HTreesLifeRule = "B1/S012345678";
		public const string IceballsLifeRule = "25678/S5678";
		public const string InverseLifeRule = "B012345678/S34678";
		public const string LandRushLifeRule = "B35/S234578";
		public const string LifeWithoutDeathLifeRule = "B3/S012345678";
		public const string LiveFreeOrDieLifeRule = "B2/S0";
		public const string LongLifeRule = "B345/S5";
		public const string LowDeathLifeRule = "B368/S238";
		public const string LowLifeRule = "B3/S13";
		public const string MazeLifeRule = "B3/S12345";
		public const string MazeWithMiceLifeRule = "B37/S12345";
		public const string MazectricLifeRule = "B3/S1234";
		public const string MazectricWithMiceLifeRule = "B37/S1234";
		public const string MoveLifeRule = "B368/S245";
		public const string PedestrianLifeRule = "B38/S23";
		public const string PlowWorldLifeRule = "B378/S012345678";
		public const string PseudoLifeRule = "B357/S238";
		public const string ReplicatorLifeRule = "B1357/S1357";
		public const string SeedsLifeRule = "B2/S";
		public const string ServiettesLifeRule = "B234/S";
		public const string SlowBlobLifeRule = "B367/S125678";
		public const string SnowLifeRule = "B3/S1237";
		public const string StainsLifeRule = "B3678/S235678";
		public const string ThirtyfourLifeRule = "B34/S34";
		public const string TwoByTwoLifeRule = "B36/S125";
		public const string WalledCitiesLifeRule = "B45678/S2345";
		public const string Vote45LifeRule = "B4678/S35678";
		public const string VoteLifeRule = "B5678/S45678";

		private int [] _birthRule;
		private int [] _sustainRule;

		public LifelikeCellularAutomataRule (string ruleString) {
			ParseRuleString (ruleString);
		}

		public int Evaluate (AutomataCell cell, int neighbors) {
			// Check the dead cells to see if they are born
			if (cell.State == 0) {
				if (_birthRule != null) {
					return _birthRule [neighbors];
				}
				return 0;
			}

			// Check the living cell to see if it survives. Living cells keep track of how long
			// they've been living.
			if (_sustainRule != null) {
				if (_sustainRule [neighbors] > 0) {
					return cell.State + 1;
				}
			}
			return 0;
		}

		private void ParseRuleString (string ruleString) {
			string [] splitRulestring = ruleString.Split (new char [] { '/' });
			if (splitRulestring.Length == 2) {
				var birthRulestring = splitRulestring [0];
				int birthLength = birthRulestring.Length;
				if (birthLength > 1) {
					birthRulestring = birthRulestring.Substring (1);
					_birthRule = new int [8];
					for (int birthIndex = 0; birthIndex < birthRulestring.Length; ++birthIndex) {
						string birthCount = birthRulestring.Substring (birthIndex, 1);
						int neighbor = Convert.ToInt32 (birthCount);
						_birthRule [neighbor] = 1;
					}
				}
				var sustainRulestring = splitRulestring [1];
				int sustainLength = sustainRulestring.Length;
				if (sustainLength > 1) {
					sustainRulestring = sustainRulestring.Substring (1);
					_sustainRule = new int [8];
					for (int sustainIndex = 0; sustainIndex < sustainRulestring.Length; ++sustainIndex) {
						string sustainCount = sustainRulestring.Substring (sustainIndex, 1);
						int neighbor = Convert.ToInt32 (sustainCount);
						_sustainRule [neighbor] = 1;
					}
				}
			} else {
				throw new Exception (string.Format ("LifelikeCellularAutomataRule: One '/' Required for Rule String '{0}'", ruleString));
			}
		}
	}
}