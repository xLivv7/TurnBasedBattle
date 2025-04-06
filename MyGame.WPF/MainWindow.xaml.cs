using System.Windows;
using MyGame.Core;

namespace MyGame.WPF
{
    public partial class MainWindow : Window
    {
        private BattleManager _battleManager;

        public MainWindow(Character first, Character second)
        {
            InitializeComponent();
            _battleManager = new BattleManager(first, second);

            UpdateUI();
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            if (!_battleManager.IsGameOver)
            {
                string msg = _battleManager.Attack();
                AppendLog(msg);
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void btnAbility_Click(object sender, RoutedEventArgs e)
        {
            if (!_battleManager.IsGameOver)
            {
                try
                {
                    string msg = _battleManager.UseAbility();
                    AppendLog(msg);
                    UpdateUI();
                }
                catch (InvalidOperationException ex)
                {
                    // W przypadku braku many – tutaj możesz wyświetlić komunikat
                    MessageBox.Show($"Ability failed: {ex.Message}\nUsing basic attack instead.");
                    _battleManager.Attack();
                }
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            if (!_battleManager.IsGameOver)
            {
                string msg = _battleManager.Heal();
                AppendLog(msg);
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void AppendLog(string message)
        {
            // Załóżmy, że masz kontrolkę TextBox o nazwie txtLog w XAML
            // Dodajemy nową linię do istniejącego tekstu
            txtLog.Text += message + Environment.NewLine;
        }
        private void UpdateUI()
        {
            // Zakładając, że interfejs ma kontrolki txtMageInfo, txtWarriorInfo, etc.
            // Możesz aktualizować np. statystyki obu postaci:
            txtMageInfo.Text = $"{_battleManager.Player1.Name}: HP={_battleManager.Player1.Health}, Mana={_battleManager.Player1.Mana}";
            txtWarriorInfo.Text = $"{_battleManager.Player2.Name}: HP={_battleManager.Player2.Health}, Mana={_battleManager.Player2.Mana}";
            // Albo uaktualnić inne elementy UI
        }
    }
}
