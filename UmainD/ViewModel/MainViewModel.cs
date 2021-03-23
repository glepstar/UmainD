using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UmainD.Models;

namespace UmainD.ViewModel
{
    class MainViewModel : BindingBase
    {
        // TODO : レースの順位を記録できるように
        // TODO : 合宿は別カウントできるように(練習レベルに影響しないため)
        // TODO : 月ごとにレースが列挙されるように

        private const int MaxTurn = 78;
        private const int MinTurn = 1;

        private static readonly int[] TrainingCampTurns = new[] { 37, 38, 39, 40, 61, 62, 63, 64 };

        #region Properties
        public ActionHistory ActionHistory { get; } = new ActionHistory();

        public int Turn
        {
            get { return ActionHistory.Turn; }
        }

        public int URACount
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.URA); }
        }
        public int G1Count
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.G1); }
        }
        public int G2Count
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.G2); }
        }
        public int G3Count
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.G3); }
        }
        public int OpenCount
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.Open); }
        }
        public int DeviewCount
        {
            get { return ActionHistory.Actions.Select(v => v as Race).Count(v => v?.RaceGrade == RaceGrade.Deview); }
        }


        public int SpeedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => !IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Speed && v?.Result == TrainingResult.Success); }
        }
        public int SpeedFriendlyCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Speed && v?.IsFriendlyTag == true && v?.Result == TrainingResult.Success); }
        }
        public int SpeedFailedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Speed && v?.Result == TrainingResult.Failed); }
        }
        public int SpeedCampCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Speed && v?.Result == TrainingResult.Success); }
        }


        public int StaminaCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => !IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Stamina && v?.Result == TrainingResult.Success); }
        }
        public int StaminaFriendlyCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Stamina && v?.IsFriendlyTag == true && v?.Result == TrainingResult.Success); }
        }
        public int StaminaFailedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Stamina && v?.Result == TrainingResult.Failed); }
        }
        public int StaminaCampCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Stamina && v?.Result == TrainingResult.Success); }
        }

        public int PowerCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => !IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Power && v?.Result == TrainingResult.Success); }
        }
        public int PowerFriendlyCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Power && v?.IsFriendlyTag == true && v?.Result == TrainingResult.Success); }
        }
        public int PowerFailedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Power && v?.Result == TrainingResult.Failed); }
        }
        public int PowerCampCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Power && v?.Result == TrainingResult.Success); }
        }

        public int GutsCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => !IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Guts && v?.Result == TrainingResult.Success); }
        }
        public int GutsFriendlyCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Guts && v?.IsFriendlyTag == true && v?.Result == TrainingResult.Success); }
        }
        public int GutsFailedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Guts && v?.Result == TrainingResult.Failed); }
        }
        public int GutsCampCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Guts && v?.Result == TrainingResult.Success); }
        }

        public int WiseCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => !IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Wise && v?.Result == TrainingResult.Success); }
        }
        public int WiseFriendlyCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Wise && v?.IsFriendlyTag == true && v?.Result == TrainingResult.Success); }
        }
        public int WiseFailedCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Count(v => v?.Kind == TrainingKind.Wise && v?.Result == TrainingResult.Failed); }
        }
        public int WiseCampCount
        {
            get { return ActionHistory.Actions.Select(v => v as Training).Where(v => IsTrainingCamp(v?.Turn ?? 0)).Count(v => v?.Kind == TrainingKind.Wise && v?.Result == TrainingResult.Success); }
        }

        public int HolidayCount
        {
            get { return ActionHistory.Actions.Select(v => v as Leisure).Count(v => v?.Kind == LeisureKind.Holiday); }

        }
        public int DateCount
        {
            get { return ActionHistory.Actions.Select(v => v as Leisure).Count(v => v?.Kind == LeisureKind.Date); }

        }
        public int InfirmaryCount
        {
            get { return ActionHistory.Actions.Select(v => v as Leisure).Count(v => v?.Kind == LeisureKind.Infirmary); }

        }

        #endregion

        #region Commands

        public ICommand ChoiceURA { get { return new DelegateCommand(OnChoiceURA, () => Turn <= MaxTurn); } }
        private void OnChoiceURA()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.URA, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        public ICommand ChoiceG1 { get { return new DelegateCommand(OnChoiceG1, () => Turn <= MaxTurn); } }
        private void OnChoiceG1()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.G1, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        public ICommand ChoiceG2 { get { return new DelegateCommand(OnChoiceG2, () => Turn <= MaxTurn); } }
        private void OnChoiceG2()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.G2, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        public ICommand ChoiceG3 { get { return new DelegateCommand(OnChoiceG3, () => Turn <= MaxTurn); } }
        private void OnChoiceG3()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.G3, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        public ICommand ChoiceOpen { get { return new DelegateCommand(OnChoiceOpen, () => Turn <= MaxTurn); } }
        private void OnChoiceOpen()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.Open, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        public ICommand ChoiceDeview { get { return new DelegateCommand(OnChoiceDeview, () => Turn <= MaxTurn); } }
        private void OnChoiceDeview()
        {
            ActionHistory.Add(new Race { RaceGrade = RaceGrade.Deview, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
        }

        #region TrainingCommands
        #region Speed Counter
        public ICommand ChoiceSpeedFriendly { get { return new DelegateCommand(OnChoiceSpeedFriendly, () => Turn <= MaxTurn); } }
        private void OnChoiceSpeedFriendly()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Speed, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = true });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceSpeedSuccess { get { return new DelegateCommand(OnChoiceSpeedSuccess, () => Turn <= MaxTurn); } }
        private void OnChoiceSpeedSuccess()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Speed, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceSpeedFailer { get { return new DelegateCommand(OnChoiceSpeedFailer, () => Turn <= MaxTurn); } }
        private void OnChoiceSpeedFailer()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Speed, Turn = Turn, Result = TrainingResult.Failed, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }
        #endregion

        #region Stamina Counter
        public ICommand ChoiceStaminaFriendly { get { return new DelegateCommand(OnChoiceStaminaFriendly, () => Turn <= MaxTurn); } }
        private void OnChoiceStaminaFriendly()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Stamina, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = true });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceStaminaSuccess { get { return new DelegateCommand(OnChoiceStaminaSuccess, () => Turn <= MaxTurn); } }
        private void OnChoiceStaminaSuccess()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Stamina, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceStaminaFailer { get { return new DelegateCommand(OnChoiceStaminaFailer, () => Turn <= MaxTurn); } }
        private void OnChoiceStaminaFailer()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Stamina, Turn = Turn, Result = TrainingResult.Failed, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }
        #endregion

        #region Power Counter
        public ICommand ChoicePowerFriendly { get { return new DelegateCommand(OnChoicePowerFriendly, () => Turn <= MaxTurn); } }
        private void OnChoicePowerFriendly()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Power, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = true });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoicePowerSuccess { get { return new DelegateCommand(OnChoicePowerSuccess, () => Turn <= MaxTurn); } }
        private void OnChoicePowerSuccess()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Power, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoicePowerFailer { get { return new DelegateCommand(OnChoicePowerFailer, () => Turn <= MaxTurn); } }
        private void OnChoicePowerFailer()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Power, Turn = Turn, Result = TrainingResult.Failed, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }
        #endregion

        #region  Guts Counter
        public ICommand ChoiceGutsFriendly { get { return new DelegateCommand(OnChoiceGutsFriendly, () => Turn <= MaxTurn); } }
        private void OnChoiceGutsFriendly()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Guts, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = true });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceGutsSuccess { get { return new DelegateCommand(OnChoiceGutsSuccess, () => Turn <= MaxTurn); } }
        private void OnChoiceGutsSuccess()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Guts, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceGutsFailer { get { return new DelegateCommand(OnChoiceGutsFailer, () => Turn <= MaxTurn); } }
        private void OnChoiceGutsFailer()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Guts, Turn = Turn, Result = TrainingResult.Failed, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }
        #endregion

        #region Wise Counter
        public ICommand ChoiceWiseFriendly { get { return new DelegateCommand(OnChoiceWiseFriendly, () => Turn <= MaxTurn); } }
        private void OnChoiceWiseFriendly()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Wise, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = true });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceWiseSuccess { get { return new DelegateCommand(OnChoiceWiseSuccess, () => Turn <= MaxTurn); } }
        private void OnChoiceWiseSuccess()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Wise, Turn = Turn, Result = TrainingResult.Success, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }

        public ICommand ChoiceWiseFailer { get { return new DelegateCommand(OnChoiceWiseFailer, () => Turn <= MaxTurn); } }
        private void OnChoiceWiseFailer()
        {
            ActionHistory.Add(new Training { Kind = TrainingKind.Wise, Turn = Turn, Result = TrainingResult.Failed, IsFriendlyTag = false });
            RaisePropertyChanged("Turn");
            UpdateTrainingCount();
        }
        #endregion
        #endregion

        public ICommand ChoiceHoliday { get { return new DelegateCommand(OnChoiceHoliday, () => Turn <= MaxTurn); } }
        private void OnChoiceHoliday()
        {
            ActionHistory.Add(new Leisure { Kind = LeisureKind.Holiday, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateLeisuresCount();
        }

        public ICommand ChoiceDate { get { return new DelegateCommand(OnChoiceDate, () => Turn <= MaxTurn); } }
        private void OnChoiceDate()
        {
            ActionHistory.Add(new Leisure { Kind = LeisureKind.Date, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateLeisuresCount();
        }

        public ICommand ChoiceInfirmary { get { return new DelegateCommand(OnChoiceInfirmary, () => Turn <= MaxTurn); } }
        private void OnChoiceInfirmary()
        {
            ActionHistory.Add(new Leisure { Kind = LeisureKind.Infirmary, Turn = Turn });
            RaisePropertyChanged("Turn");
            UpdateLeisuresCount();
        }

        public ICommand Undo { get { return new DelegateCommand(OnUndo, () => Turn > MinTurn); } }
        private void OnUndo()
        {
            ActionHistory.Remove();
            RaisePropertyChanged("Turn");
            UpdateRaceCount();
            UpdateTrainingCount();
            UpdateLeisuresCount();
        }

        #endregion

        private bool IsTrainingCamp(int turn)
        {
            return TrainingCampTurns.Contains(turn);
        }

        private void Update()
        {
            RaisePropertyChanged("Turn");

            UpdateRaceCount();
            UpdateTrainingCount();
            UpdateLeisuresCount();
        }

        private void UpdateRaceCount()
        {
            RaisePropertyChanged("URACount");
            RaisePropertyChanged("G1Count");
            RaisePropertyChanged("G2Count");
            RaisePropertyChanged("G3Count");
            RaisePropertyChanged("OpenCount");
            RaisePropertyChanged("DeviewCount");
        }

        private void UpdateTrainingCount()
        {
            RaisePropertyChanged("SpeedFriendlyCount");
            RaisePropertyChanged("SpeedCount");
            RaisePropertyChanged("SpeedFailedCount");
            RaisePropertyChanged("SpeedCampCount");
            RaisePropertyChanged("StaminaFriendlyCount");
            RaisePropertyChanged("StaminaCount");
            RaisePropertyChanged("StaminaFailedCount");
            RaisePropertyChanged("StaminaCampCount");
            RaisePropertyChanged("PowerFriendlyCount");
            RaisePropertyChanged("PowerCount");
            RaisePropertyChanged("PowerFailedCount");
            RaisePropertyChanged("PowerCampCount");
            RaisePropertyChanged("GutsFriendlyCount");
            RaisePropertyChanged("GutsCount");
            RaisePropertyChanged("GutsFailedCount");
            RaisePropertyChanged("GutsCampCount");
            RaisePropertyChanged("WiseFriendlyCount");
            RaisePropertyChanged("WiseCount");
            RaisePropertyChanged("WiseFailedCount");
            RaisePropertyChanged("WiseCampCount");
        }
        private void UpdateLeisuresCount()
        {
            RaisePropertyChanged("HolidayCount");
            RaisePropertyChanged("DateCount");
            RaisePropertyChanged("InfirmaryCount");
        }
    }
}
