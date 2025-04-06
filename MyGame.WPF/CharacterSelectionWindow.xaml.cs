using System.Windows;
using MyGame.Core; // Namespace z Twoimi klasami postaci

namespace MyGame.WPF
{
    public partial class CharacterSelectionWindow : Window
    {
        private Character _firstFighter;
        private Character _secondFighter;
        private bool _choosingFirst = true; // flaga, czy wybieramy pierwszą, czy drugą postać

        public CharacterSelectionWindow()
        {
            InitializeComponent();
        }

        private void Mage_Click(object sender, RoutedEventArgs e)
        {
            SelectFighter(new Mage("Mage", 100, 20, 5, "Arcane Blast", 50, 0, 50, 30));
        }

        private void Warrior_Click(object sender, RoutedEventArgs e)
        {
            SelectFighter(new Warrior("Warrior", 120, 18, 8, "Power of Justice", 40, 0, 50, 30));
        }

        private void Defender_Click(object sender, RoutedEventArgs e)
        {
            SelectFighter(new Defender("Defender", 150, 10, 15, "Shield Slam", 20, 0, 60, 30));
        }

        private void Archer_Click(object sender, RoutedEventArgs e)
        {
            SelectFighter(new Archer("Archer", 90, 35, 3, "Poisoned Arrows", 30, 0, 40, 35));
        }

        // Metoda obsługująca wybór postaci
        private void SelectFighter(Character chosen)
        {
            if (_choosingFirst)
            {
                _firstFighter = chosen;
                txtInstruction.Text = "Choose second fighter";
                _choosingFirst = false;
            }
            else
            {
                _secondFighter = chosen;
                // Pokazujemy przycisk "Start Battle"
                btnConfirm.Visibility = Visibility.Visible;
                txtInstruction.Text = $"First: {_firstFighter.Name}, Second: {_secondFighter.Name}\nClick 'Start Battle'!";
            }
        }

        // Po kliknięciu "Start Battle" – otwieramy okno walki (MainWindow) i przekazujemy wybrane postacie
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy obie postacie wybrane
            if (_firstFighter == null || _secondFighter == null)
            {
                MessageBox.Show("Please select both fighters!");
                return;
            }

            var battleWindow = new MainWindow(_firstFighter, _secondFighter);
            battleWindow.Show();
            this.Close();

        }
    }
}
