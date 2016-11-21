using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Android.Util;
using DigitalPages.Marvel.Constants;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Core.Models;
using Newtonsoft.Json;
using MarvelApi = ME.Rmenezes.Digitalpages.Characters;

namespace DigitalPages.Marvel.Droid.Services
{
	public class MarvelDroidService : IMarvelService
	{
		private readonly MarvelApi _marvelApi;
		private const string TAG = nameof(MarvelDroidService);

		public MarvelDroidService()
		{
			var timestamp = "1234";
			var hash = GetMd5($"{timestamp}{AppSettings.ApiPrivateKey}{AppSettings.ApiPublicKey}");
			_marvelApi = new MarvelApi(AppSettings.ApiKey,
									   AppSettings.ApiUrl,
									   timestamp,
									   hash);
		}

		public async Task<Character> GetById(long id)
		{
			try
			{
				var result = _marvelApi.GetDetails(id);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CharacterResult.ApiResult>(result));

					if (data != null)
					{
						return data.Data.Results.Select(p => new Character
						{
							Avatar = $"{p.Thumbnail.Path}.{p.Thumbnail.Extension}",
							Id = p.Id,
							Description = p.Description,
							Name = p.Name
						}).FirstOrDefault();
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error(TAG, ex.Message);
			}

			return new Character();
		}

		public async Task<ICollection<Character>> GetCharacters(string name = "", int skip = 0, int limit = 20)
		{
			try
			{
				var result = _marvelApi.GetAll(name);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CharacterResult.ApiResult>(result));

					if (data != null)
					{
						return data.Data.Results.Select(p => new Character
						{
							Avatar = $"{p.Thumbnail.Path}.{p.Thumbnail.Extension}",
							Id = p.Id,
							Description = p.Description,
							Name = p.Name
						}).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error(TAG,ex.Message);
			}

			return new List<Character>();
		}

		public async Task<ICollection<Comic>> GetComicsByIdCharacter(long id, int skip = 0, int limit = 20)
		{
			try
			{
				var result = _marvelApi.GetComicsByIdCharacter(id);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ComicResult.ApiResult>(result));

					if (data != null)
					{
						return data.Data.Results.Select(p => new Comic
						{
							Thumb = $"{p.Thumbnail.Path}.{p.Thumbnail.Extension}",
							Name = p.Title
						}).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error(TAG, ex.Message);
			}

			return new List<Comic>();
		}

		private string GetMd5(string input)
		{
			using (var md5 = MD5.Create())
			{
				byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
				var strBuilder = new StringBuilder();

				for (int i = 0; i < data.Length; i++)
				{
					strBuilder.Append(data[i].ToString("x2"));
				}

				return strBuilder.ToString();
			}
		}
	}
}
