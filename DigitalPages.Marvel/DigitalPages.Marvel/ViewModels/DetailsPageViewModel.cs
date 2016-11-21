using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace DigitalPages.Marvel.ViewModels
{
	public class DetailsPageViewModel : BindableBase, INavigationAware
	{
		private IMarvelService _serviceMarvel;
		private IUserDialogs _userDialogs;

		#region Bindable Properties

		/// <summary>
		/// DataSource
		/// </summary>
		/// <value>The data source.</value>
		private ObservableCollection<Comic> _dataSource;
		public ObservableCollection<Comic> DataSource
		{
			get { return _dataSource; }
			set { SetProperty(ref _dataSource, value); }
		}

		private string _thumb;
		public string Thumb
		{
			get { return _thumb; }
			set { SetProperty(ref _thumb, value); }
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}

		#endregion Bindable Properties

		public DetailsPageViewModel(IMarvelService marvelService,
		                            IUserDialogs userDialogs)
		{
			_serviceMarvel = marvelService;
			_userDialogs = userDialogs;
			DataSource = new ObservableCollection<Comic>();
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("characterId"))
				LoadDataAsync((long)parameters["characterId"]);
		}

		private async Task LoadDataAsync(long id)
		{
			using (var loading = _userDialogs.Loading("Carregando"))
			{
				var result = await _serviceMarvel.GetById(id);

				if (result == null)
					return;

				Title = result.Name;
				Thumb = result.Avatar;
				Description = result.Description;

				var comics = await _serviceMarvel.GetComicsByIdCharacter(id);
				DataSource = new ObservableCollection<Comic>(comics);
			}
		}
	}
}
	