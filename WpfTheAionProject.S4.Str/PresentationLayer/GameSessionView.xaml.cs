using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTheAionProject.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeWindowTheme();

            InitializeComponent();
        }

        private void InitializeWindowTheme()
        {
            this.Title = "Laughing Leaf Productions";
        }

        private void NorthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }

        private void EastTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }

        private void SouthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }

        private void WestTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }

        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameSessionViewModel.OnUseGameItem();
            }
        }
        // todo 27 - create a method handle the click event for the Speak To button
        //private void SpeakToButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (LocationNpcsDataGrid.SelectedItem != null)
        //    {
        //        _gameSessionViewModel.OnPlayerTalkTo();
        //    }
        //}

        // todo 28 - create a methods handle the click event for the player's battle choices
        //private void AttackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (LocationNpcsDataGrid.SelectedItem != null)
        //    {
        //        _gameSessionViewModel.OnPlayerAttack();
        //    }
        //}

        //private void DefendButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (LocationNpcsDataGrid.SelectedItem != null)
        //    {
        //        _gameSessionViewModel.OnPlayerDefend();
        //    }
        //}

        //private void RetreatButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (LocationNpcsDataGrid.SelectedItem != null)
        //    {
        //        _gameSessionViewModel.OnPlayerRetreat();
        //    }
        //}

        // todo 29 - [In View] add tab control to display all NPC's in the current location
        // todo 30 - [In View] add a "Talk To" button
        // todo 31 - [In View] add "Attack", "Defend", and "Retreat" buttons
    }
}