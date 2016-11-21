using DigitalPages.Marvel.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;
using System.Collections.Generic;
using System;
using DigitalPages.Marvel.Core.Interfaces;

namespace DigitalPages.Marvel.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		/// <summary>
		/// Collection original sem filtro
		/// </summary>
		/// <value>The original data source.</value>
		private ICollection<Character> _originalDataSource;
		private INavigationService _navigationService;
		private IMarvelService _marvelService;

		/// <summary>
		/// DataSource
		/// </summary>
		/// <value>The data source.</value>
		private ObservableCollection<Character> _dataSource;
		public ObservableCollection<Character> DataSource 
		{ 
			get { return _dataSource; }
			set { SetProperty(ref _dataSource, value); }
		}

		/// <summary>
		/// Binding do campo de busca
		/// </summary>
		private string _search;
		public string Search
		{
			get { return _search; }
			set { SetProperty(ref _search, value); }
		}

		/// <summary>
		/// Comando de Busca
		/// </summary>
		/// <value>The search command.</value>
		public ICommand SearchCommand { get; set; }
		public ICommand ClearCommand { get; set; }
		public ICommand ItemTappedCommand { get; set; }
		public ICommand LoadDataCommand { get; set; }

		public MainPageViewModel(INavigationService navigationService,
		                         IMarvelService marvelService)
		{
			_navigationService = navigationService;
			_marvelService = marvelService;

			DataSource = new ObservableCollection<Character>();

			SearchCommand = new DelegateCommand(async () => await SearchCommandHandler());
			ClearCommand = new DelegateCommand(async () => await ClearCommandHandler());
			ItemTappedCommand = new DelegateCommand<Character>(ItemTappedCommandHandler);
			LoadDataCommand = new DelegateCommand(async () => await LoadDataCommandHandler());

			LoadDataCommand?.Execute(null);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

		public void ItemTappedCommandHandler(Character item)
		{
			var parameters = new NavigationParameters();
			parameters.Add("characterId", item.Id);

			_navigationService.NavigateAsync("DetailsPage", parameters, animated: true);
		}

		public async Task LoadDataCommandHandler()
		{
			_originalDataSource = await _marvelService.GetCharacters();
			DataSource = new ObservableCollection<Character>(_originalDataSource);
		}

		public Task SearchCommandHandler()
		{
			// Do it in background
			return Task.Factory.StartNew(async () =>
			{
				if (string.IsNullOrEmpty(Search))
					DataSource = new ObservableCollection<Character>(_originalDataSource);
				else
				{
					var filteredList = await _marvelService.GetCharacters(Search);
					DataSource = new ObservableCollection<Character>(filteredList);
				}
			});
		}

		public Task ClearCommandHandler()
		{
			return Task.Factory.StartNew(() =>
			{
				DataSource = new ObservableCollection<Character>(_originalDataSource);
			});
		}
	}
}

