using System.Collections.Generic;
using Caliburn.Micro;
using TrueOrFalse.Models;

namespace TrueOrFalse.ViewModels
{
    public class GameViewModel : Screen
    {
        private List<Statement> _statements;
        private IDialogService _dialogService;

        public GameViewModel(List<Statement> statements, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _statements = statements;

            ShowNext();
        }

        protected override void OnActivate()
        {
            DisplayName = "Game";
        }

        private void ShowNext()
        {
            StatementNumber++;
            StatementText = _statements[StatementNumber - 1].Text;
        }

        public string StatementText { get; set; }

        public void Exit()
        {

        }

        public void False()
        {
            ProcessAnswer(false);
        }

        public void True()
        {
            ProcessAnswer(true);
        }

        private void ProcessAnswer(bool answer)
        {
            bool isCorrect = answer == CurrentStatement.IsTrue;
            if (isCorrect)
            {
                Score++;
            }

            if (EndOfGame())
            {
                GameResult result = GetResult(Score, NumberOfStatements);
                _dialogService.OpenInfoWindow("Result", result.ToString());

                TryClose();
            }
            else
            {
                ShowNext();
            }
        }

        public int StatementNumber { get; set; }

        public int NumberOfStatements { get; set; }

        public int Score { get; set; }

        public Statement CurrentStatement => _statements[StatementNumber - 1];

        public GameResult GetResult(int scores, int numberOfStatements)
        {
            double result = (double) scores * 100 / numberOfStatements;
            return result > 70 ? GameResult.Win : GameResult.Loss;
        }

        public bool EndOfGame()
        {
            return StatementNumber == _statements.Count;
        }
    }


    public enum GameResult
    {
        Loss,
        Win
    }
}
