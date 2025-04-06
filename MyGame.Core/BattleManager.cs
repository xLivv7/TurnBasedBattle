using System;

namespace MyGame.Core
{
    // Klasa BattleManager zarządza bitwą między dwoma postaciami.
    public class BattleManager
    {
        // Publiczne właściwości, dzięki którym UI może odczytać stan gry.
        public Character Player1 { get; }
        public Character Player2 { get; }

        // Pole określające, która postać ma turę.
        private bool _isPlayer1Turn = true;

        // Konstruktor – przekazuje dwie postacie.
        public BattleManager(Character player1, Character player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        // Zwraca aktualnego gracza oraz przeciwnika.
        public Character CurrentPlayer => _isPlayer1Turn ? Player1 : Player2;
        public Character Opponent => _isPlayer1Turn ? Player2 : Player1;

        // Metoda wykonująca akcję ataku przez aktualnego gracza.
        public string Attack()
        {
            
            string msg = CurrentPlayer.Attack(Opponent);
            RegenerateManaForCurrentPlayer();
            EndTurn();
            return msg;
        }

        // Metoda wykonująca akcję użycia umiejętności.
        // Jeśli aktualny gracz nie ma wystarczająco many, możesz zdecydować, czy wykonać atak podstawowy.
        public string UseAbility()
        {
            string msg;
            if (!CurrentPlayer.CanUseAbility)
            {
                msg= $"{CurrentPlayer.Name} doesn't have enough mana to use ability, performing basic attack instead!";
                msg += "\n" +CurrentPlayer.Attack(Opponent);
            }
            else
            {
                msg = CurrentPlayer.UseAbility(Opponent);
            }
            RegenerateManaForCurrentPlayer();
            EndTurn();
            return msg;
        }


        // Metoda wykonująca akcję leczenia, jeśli gracz ma przedmiot leczniczy.
        // Jeśli nie, można wybrać inny mechanizm (np. atak podstawowy).
        public string Heal()
        {
            string msg;
            if (CurrentPlayer.HealingItem <= 0)
            {
                msg= $"{CurrentPlayer.Name} has no healing items left!";
                return msg;
            }
            msg = CurrentPlayer.Heal();
            RegenerateManaForCurrentPlayer();
            EndTurn();
            return msg;
        }

        // Prywatna metoda – regeneruje manę aktualnego gracza po akcji.
        private void RegenerateManaForCurrentPlayer()
        {
            // Przykład: regeneracja 5 punktów many
            CurrentPlayer.RegenerateMana(5);
        }

        // Prywatna metoda – kończy turę i przełącza aktualnego gracza.
        private void EndTurn()
        {
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        // Właściwość informująca, czy bitwa się zakończyła.
        public bool IsGameOver => Player1.Health <= 0 || Player2.Health <= 0;
    }
}
