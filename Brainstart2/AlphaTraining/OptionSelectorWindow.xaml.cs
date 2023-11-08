﻿using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace AlphaTraining
{
    public enum ApplicationMode
    {
        None,

        NewUser,

        StaticAnalysis
    }

    /// <summary>
    /// Interaction logic for OptionSelectorWindow.xaml
    /// </summary>
    public partial class OptionSelectorWindow : Window
    {
        string _userName = string.Empty;
        List<string> _usersList = new List<string>();

        ApplicationMode _applicationMode = ApplicationMode.None;

        public OptionSelectorWindow()
        {
            InitializeComponent();

            // Перечислить существующих пользователей
            foreach (var filename in Directory.GetDirectories(@".\Data\users"))
            {
                _usersList.Add(Path.GetFileName(filename));
            }

            _usersList.Add("<Новый пользователь>");

            lbUsersList.ItemsSource = _usersList;
        }

        private void CreateNewUser()
        {
            // Показать диалоговое окно ввода имения пользователя
            NewUserDialog newUserDialog = new NewUserDialog();
            newUserDialog.ShowDialog();

            // В случае успеха сохранить имя пользователя
            if(true == newUserDialog.DialogResult)
            {
                _userName = newUserDialog.GetUrerName();
                _applicationMode = ApplicationMode.NewUser;
                Close();
            }
        }

        private void btnAnalysis_Click(object sender, RoutedEventArgs e)
        {
            ChooseOption();
        }

        public ApplicationMode GetApplicationMode()
        {
            return _applicationMode;
        }

        public string GetUserName()
        {
            return _userName;
        }

        private void lbUsersList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChooseOption();
        }

        private void ChooseOption()
        {
            if (lbUsersList.SelectedItem != null)
            {
                if (lbUsersList.SelectedIndex == (_usersList.Count - 1))
                {
                    // Добавить нового пользователя
                    CreateNewUser();
                }
                else
                {
                    MessageBox.Show("Функционал скоро будет написан :)");
                }
            }
        }
    }
}
