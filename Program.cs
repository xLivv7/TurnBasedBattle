﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurnBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy dwie przykładowe postacie:
            Character mage = new Mage("Merlin", 100, 20, 5, "Arcane Blast", 50);
            Character warrior = new Warrior("Aragorn", 120, 15, 10, "Power of Justice", 40);

            // Rozpoczynamy bitwę
            Battle(mage, warrior);

            // Po zakończeniu czekamy na klawisz, żeby zobaczyć wynik w konsoli
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void Battle(Character player1, Character player2)
        {
            Console.WriteLine("=== BATTLE START ===");
            Console.WriteLine($"{player1.Name} (HP: {player1.Health}) VS {player2.Name} (HP: {player2.Health})");

            // Pętla, dopóki obie postacie żyją
            while (player1.Health > 0 && player2.Health > 0)
            {
                // Tura Player1
                TakeTurn(player1, player2);
                if (player2.Health <= 0) break; // Jeśli player2 padł, kończymy

                // Tura Player2
                TakeTurn(player2, player1);
                if (player1.Health <= 0) break; // Jeśli player1 padł, kończymy

                // Po każdej pełnej rundzie wypisujemy stan zdrowia
                Console.WriteLine();
                Console.WriteLine($"Current HP: {player1.Name} = {player1.Health}, {player2.Name} = {player2.Health}");
                Console.WriteLine();
            }

            // Po wyjściu z pętli wiemy, że ktoś ma HP <= 0
            if (player1.Health <= 0 && player2.Health <= 0)
            {
                Console.WriteLine("It's a draw! Both fighters have fallen.");
            }
            else if (player1.Health <= 0)
            {
                Console.WriteLine($"{player1.Name} was defeated. {player2.Name} wins!");
            }
            else
            {
                Console.WriteLine($"{player2.Name} was defeated. {player1.Name} wins!");
            }

            Console.WriteLine("=== BATTLE END ===");
        }

        static void TakeTurn(Character actingPlayer, Character opponent)
        {
            // Wyświetlamy menu
            Console.WriteLine($"\n--- {actingPlayer.Name}'s turn ---");
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1 - Attack");
            Console.WriteLine("2 - Use Ability (if available)");
            Console.Write("Your choice: ");

            // Wczytujemy wybór z klawiatury
            string input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        actingPlayer.Attack(opponent);
                        break;
                    case "2":
                        // Sprawdzamy, czy faktycznie można użyć Ability
                        if (actingPlayer.CanUseAbility)
                        {
                            actingPlayer.UseAbility(opponent);
                        }
                        else
                        {
                            Console.WriteLine("Ability not ready yet, using basic attack instead!");
                            actingPlayer.Attack(opponent);
                        }
                        break;
                    default:
                        // Niepoprawny wybór -> atakujemy domyślnie
                        Console.WriteLine("Invalid choice, defaulting to basic attack!");
                        actingPlayer.Attack(opponent);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Jeśli np. target == null, albo Ability not ready, wylądujemy tutaj
                Console.WriteLine($"Error while {actingPlayer.Name} tries to act: {ex.Message}");
            }
        }
    }
}