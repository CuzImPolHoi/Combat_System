using System;

namespace Combat_System
{
	class Program
	{
		static void Main(string[] args)
		{
			Player Player = new Player();
			Rat Rat = new Rat();
			Random rnd = new Random();
			
			Console.WriteLine("Uh oh, a rat is attacking you!");
			do
			{
				// initiating combat with a rat
				Rat.level = 1;
				Console.CursorVisible = false;
				Console.Write("\n\n\n");
				Console.WriteLine("Rat");                        // displays
				Console.WriteLine("Level {0}", Rat.level);       // name and stats
				Console.WriteLine("HP: {0}", Rat.health);        // of the rat.
				Console.Write("\n\n\n");
				Console.WriteLine("Your Level: " + Player.level);
				Console.WriteLine("Your HP: " + Player.health);
				Console.Write("\n");
				Console.WriteLine("(A)ttack   (D)efense");       // displays
				Console.WriteLine(" (H)eal      (F)lee ");       // opportunities.
				string combatAction = Console.ReadLine();                                 // input for action     

				//====================================================================================================== Player actions (player attacks always first)
				
				if (combatAction == "Attack" || combatAction == "A" || combatAction == "attack" || combatAction == "a")
				{
					WriteWithColor("You attack the Rat!", ConsoleColor.Green);
					Player.attacking = true;
				}
				
				if (combatAction == "Defense" || combatAction == "D" || combatAction == "defense" || combatAction == "d")
				{
					WriteWithColor("You defend yourself!", ConsoleColor.Green);
					Player.defending = true;
				}

				if (combatAction == "Heal" || combatAction == "H" || combatAction == "heal" || combatAction == "h")
				{
					Console.WriteLine("Healing doesn't work yet.");
				}

				if (combatAction == "Flee" || combatAction == "F" || combatAction == "flee" || combatAction == "f")
				{
					Console.WriteLine("Fleeing doesn't work yet.");
				}

				Console.ReadKey();
				Console.WriteLine("\n\n\n");
				
				//====================================================================================================== Enemy actions (enemy attacks always after player)

				int attackordefend = rnd.Next(1, 11);
				if (Player.health <= Player.health / 100 * 10)
				{ 
					WriteWithColor("The Rat attacks you!", ConsoleColor.Red);
					Rat.attacking = true;
				}
				
				else if (Rat.health <= Rat.health / 100 * 40)
				{
					if (attackordefend >= 4)
					{

						WriteWithColor("The Rat defends itself!", ConsoleColor.Red);
						Rat.defending = true;
					}

					if (attackordefend < 4)
					{
						WriteWithColor("The Rat attacks you!", ConsoleColor.Red);
						Rat.attacking = true;
					}
				}

				else
				{
					if (attackordefend >= 8)
					{
						WriteWithColor("The Rat defends itself!", ConsoleColor.Red);
						Rat.defending = true;
					}

					if (attackordefend < 8)
					{
						WriteWithColor("The Rat attacks you!", ConsoleColor.Red);
						Rat.attacking = true;
					}
				}

				Console.ReadKey();
				Console.WriteLine("\n\n\n");
				
				//====================================================================================================== Damage calculation

				if (Player.attacking == true)
				{
					if (Rat.defending == false)
					{
						WriteWithColor("You dealt " + Player.attackDamage + " damage to the rat", ConsoleColor.Green);
						Rat.health = Rat.health - Player.attackDamage;
						if (Rat.health <= 0)
						{
							Rat.health = 0;
						}
					}

					if (Rat.defending == true)
					{
						WriteWithColor("You dealt " + Player.attackDamage / 2 + " damage to the rat", ConsoleColor.Green);
						Rat.health = Rat.health - Player.attackDamage / 2;
						if (Rat.health <= 0)
						{
							Rat.health = 0;
						}
					}
				}

				if (Rat.attacking == true)
				{
					if (Player.defending == false)
					{
						WriteWithColor("The Rat dealt " + Rat.attackDamage + " damage to you", ConsoleColor.Red);
						Player.health = Player.health - Rat.attackDamage;
						if (Player.health <= 0)
						{
							Player.health = 0;
						}
					}

					if (Player.defending == true)
					{
						WriteWithColor("The Rat dealt " + Rat.attackDamage / 2 + " damage to you", ConsoleColor.Red);
						Player.health = Player.health - Rat.attackDamage / 2;
						if (Player.health <= 0)
						{
							Player.health = 0;
						}
					}
				}
				
				Player.attacking = false;
				Player.defending = false;
				Rat.attacking = false;
				Rat.defending = false;

				Console.ReadKey();
				Console.Clear();

			} while (Rat.health != 0 && Player.health != 0);

			if (Player.health != 0 && Rat.health == 0)
			{
				WriteWithColor("Congratulations! You win against a rat. But that shouldn't be a challenge, right?", ConsoleColor.Green);
				WriteWithColor("You get " + Rat.gold + " gold", ConsoleColor.Green);
				Player.gold = Player.gold + Rat.gold;
				WriteWithColor("You gain " + Rat.EXP + "EXP", ConsoleColor.Green);
				Player.EXP = Player.EXP + Rat.EXP;
			}

			else if (Player.health == 0 && Rat.health != 0)
			{
				WriteWithColor("You lose against a fucking Rat? That was the first enemy of the game goddamnit. Good luck then.", ConsoleColor.Red);
			}

			else
			{
				Console.WriteLine("Something went wrong lol");
			}

			Console.ReadKey();
			Console.Clear();
			
			Console.WriteLine("The game is now over. Press any button to terminate the application.");
			Console.ReadKey();
		}

		static void WriteWithColor(string text, ConsoleColor color)
		{
			ConsoleColor previousColor = Console.ForegroundColor;
			Console.ForegroundColor = color;

			Console.WriteLine(text);

			Console.ForegroundColor = previousColor;
		}
	}
}