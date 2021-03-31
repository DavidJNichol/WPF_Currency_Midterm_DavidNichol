using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Currency;
using Currency.US;

namespace WPF_Currency_Midterm_DavidNichol
{
    public class CurrencyRepoViewModel :INotifyPropertyChanged
    {
        
        private USCurrencyRepo currencyRepo;      
        public ICommand AddToTotal { get; set; }
        public ICommand DisplayCoinsForChange { get; set; }
        public ICommand Save { get; set; }

        public ICommand Load { get; set; }

        public ICommand New { get; set; }

        public int NumCoins { get; set; }

        public ObservableCollection<ICoin> CoinsList { get; set; }
        
        public ICoin SelectedCoin { get; set; }

        private Repo repository;

        public static ObservableCollection<USCurrencyRepo> page;


        public ObservableCollection<USCurrencyRepo> Page
        {
            get
            {
                return page;
            }
            set
            {
                if (value != page)
                {
                    page = value;
                }
            }
        }

        public string CoinsAbout
        {
            get { return currencyRepo.about; }
            set
            {
                currencyRepo.about = value;
                RaisePropertyChanged("CoinsAbout");
            }
        }

        public decimal Amount 
        {
            get {return currencyRepo.amount; } 
            set 
            {
                currencyRepo.amount = value;
                RaisePropertyChanged("Amount");
            } 
        }

        public decimal Total
        {
            get { return currencyRepo.amount; }
            set { currencyRepo.amount = value;
                RaisePropertyChanged("Total");
            }
        }

        public ICurrencyRepo MakeChangeForRepo
        {
            get { return USCurrencyRepo.MakeChange(Amount, currencyRepo); }
            set { currencyRepo.changeRepo = value;
                RaisePropertyChanged("MakeChangeForRepo");
            }
        }


        public CurrencyRepoViewModel(USCurrencyRepo currencyRepo)
        {
            this.currencyRepo = currencyRepo;
            this.DisplayCoinsForChange = new ViewModelCommand(MakeChange, CanMakeChange);
            this.AddToTotal = new ViewModelCommand(AddTotal, CanAddToTotal);
            this.Save = new ViewModelCommand(SavePage, CanSave);
            this.Load = new ViewModelCommand(LoadPage, CanLoad);
            this.New = new ViewModelCommand(MakeNew, CanNew);

            NumCoins = 1;

            repository = new Repo();

            CoinsList = new ObservableCollection<ICoin>();
            
            foreach(ICoin c in USCoin.GetUSCoinList())
            {
                CoinsList.Add(c);
            }

            Page = new ObservableCollection<USCurrencyRepo>();
            Page.Add(currencyRepo);
        }

        private bool CanMakeChange(object parameter)
        {
            return true;
        }

        public void MakeChange(object parameter)
        {
            currencyRepo.About();
            RaisePropertyChanged("Amount");
            RaisePropertyChanged("MakeChangeForRepo");
       
            MakeChangeForRepo = USCurrencyRepo.MakeChange(Amount, currencyRepo);

            RaisePropertyChanged("CoinsAbout");
            //DisplayCoins(CoinsAbout);
        }

        private bool CanAddToTotal(object parameter)
        {
            return true;
        }

        public void AddTotal(object parameter)
        {
            for(int i = 0; i < NumCoins; i++)
            {
                currencyRepo.AddCoin(SelectedCoin);
            }

            currencyRepo.TotalValue();

            RaisePropertyChanged(nameof(Total));
        }

        private bool CanSave(object parameter)
        {
            return true;
        }

        public void SavePage(object parameter)
        {
            Page.RemoveAt(0);
            Page.Add(currencyRepo);
            if (repository.entry != Page[0])
            {
                repository.entry = Page[0];
            }

            repository.Save();
        }

        private bool CanLoad(object parameter)
        {
            if (Page.Count == 0)
            {
                return false;
            }

            return true;
        }

        public void LoadPage(object parameter)
        {
            USCurrencyRepo repo = repository.Load();

            this.currencyRepo = repo;

            RaisePropertyChanged("Total");
            RaisePropertyChanged("CoinsAbout");
        }

        private bool CanNew(object parameter)
        {
            return true;
        }

        public void MakeNew(object parameter)
        {
            currencyRepo = new USCurrencyRepo();

            RaisePropertyChanged("Total");
            RaisePropertyChanged("CoinsAbout");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class ViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public delegate void ICommandOnExecute(object parameter);

        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public ViewModelCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }

}
