using System;
using System.Security.RightsManagement;
using System.Windows;
using Caliburn.Micro;
using TrueOrFalse.Models;

namespace TrueOrFalse.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IPersistence _persistence;
        private readonly IDialogService _dialog;
        private readonly IWindowManager _windowManager;
        private int _currentNumber;

        public MainViewModel(IPersistence persistence, IDialogService dialog, IWindowManager windowManager)
        {
            _persistence = persistence;
            _dialog = dialog;
            _windowManager = windowManager;

            CurrentStatement = new Statement();
            CurrentNumber = 1;

            CurrentStatement.PropertyChanged += (sender, args) => { UpdateButtonsState(); };
        }

        protected override void OnActivate()
        {
            DisplayName = "TrueOrFalse";
        }

        public Statement CurrentStatement { get; set; }

        public void AddStatement()
        {
            _persistence.Add(GetCurrentStatementState());
            CurrentNumber++;

            CurrentStatement.Text = "";
            CurrentStatement.IsTrue = false;

            NotifyOfPropertyChange(()=> CurrentStatement);
        }

        private Statement GetCurrentStatementState()
        {
            return new Statement(CurrentStatement.Text, CurrentStatement.IsTrue);
        }

        public void SaveStatement()
        {
            UpdateCurrentStatement();
            CurrentNumber++;
        }

        private void UpdateCurrentStatement()
        {
            if (GetCurrentIndex() < _persistence.Count)
                _persistence.Change(GetCurrentIndex(), GetCurrentStatementState());
        }

        public void RemoveStatement()
        {
            if (GetCurrentIndex() < _persistence.Count)
            {
                _persistence.Remove(GetCurrentIndex());

                if (CurrentNumber > 1)
                {
                    CurrentNumber--;
                }
                else
                {
                    CurrentNumber = 1;
                }
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void StartGame()
        {
            _windowManager.ShowDialog(new GameViewModel(_persistence.List, _dialog));
        }

        public int CurrentNumber
        {
            get => _currentNumber;
            set
            {
                _currentNumber = value;
                SetCurrentState(GetCurrentIndex());

                NotifyOfPropertyChange();
            }
        }

        private void SetCurrentState(int index)
        {
            if (index < _persistence.Count)
            {
                CurrentStatement.Text = _persistence[index].Text;
                CurrentStatement.IsTrue = _persistence[index].IsTrue;
            }
            else
            {
                CurrentStatement.Text = string.Empty;
                CurrentStatement.IsTrue = false;
            }

            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            NotifyOfPropertyChange(nameof(CanSaveStatement));
            NotifyOfPropertyChange(nameof(CanRemoveStatement));
            NotifyOfPropertyChange(nameof(CanAddStatement));
        }

        private int GetCurrentIndex()
        {
            return CurrentNumber == 0 ? 0 : CurrentNumber - 1;
        }

        public bool CanSaveStatement => !IsStatementEmpty && _persistence.Exists(GetCurrentIndex());

        public bool CanRemoveStatement => _persistence.Exists(GetCurrentIndex());

        public bool CanAddStatement => !IsStatementEmpty && !_persistence.Exists(GetCurrentIndex());

        public bool IsStatementEmpty => string.IsNullOrWhiteSpace(CurrentStatement.Text);

        public void SaveDb()
        {
            _persistence.Save();
        }

        public void Paste()
        {
            CurrentStatement.Text = Clipboard.GetText();
        }
        public void Copy()
        {
            Clipboard.SetText(CurrentStatement.Text);
        }
        public void Cut()
        {
            Clipboard.SetText(CurrentStatement.Text);
            CurrentStatement.Text = string.Empty;
        }
        public void SaveDbAs()
        {
            DialogResult dialog = _dialog.SaveFileDialog();
            if (dialog.Result == true)
                _persistence.Save();
        }

        public void OpenDb()
        {
            DialogResult dialog = _dialog.OpenFileDialog();
            if (dialog.Result == true)
            {
                _persistence.FileName = dialog.FileName;
                _persistence.Load();

                CurrentNumber = 1;
            }
        }

        public void NewDb()
        {
            var dialog = _dialog.SaveFileDialog();
            if (dialog.Result == true)
            {
                _persistence.FileName = dialog.FileName;
                _persistence.Save();

                CurrentNumber = 1;
                CurrentStatement.Text = string.Empty;
                CurrentStatement.IsTrue = false;
            }
        }

    }
}