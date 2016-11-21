using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigitalPages.Marvel.Constants;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Core.Models;
using Newtonsoft.Json;
using MarvelApi = DigitalPages.Marvel.Api.iOS.Characters;

namespace DigitalPages.Marvel.iOS.Services
{
	public class MarveliOSService : IMarvelService
	{
		private MarvelApi _marvelApi;

		public MarveliOSService()
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
				var result = await _marvelApi.GetDetailsWithAsync((nint)id);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IList<CharacterResult.Result>>(result));

					if (data != null)
					{
						return data.Select(p => new Character
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
				Console.WriteLine($"Native error library: {ex.Message}");
				throw ex;
			}

			return new Character();
		}

		public async Task<ICollection<Character>> GetCharacters(string name = "", int skip = 0, int limit = 20)
		{
			try
			{
				var result = await _marvelApi.GetAllWithNameAsync(name);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IList<CharacterResult.Result>>(result));

					if (data != null)
					{
						return data.Select(p => new Character
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
				Console.WriteLine($"Native error library: {ex.Message}");
				throw ex;
			}

			return new List<Character>();
		}

		public async Task<ICollection<Comic>> GetComicsByIdCharacter(long id, int skip = 0, int limit = 20)
		{
			try
			{
				var result = await _marvelApi.GetComicsWithIdCharacterAsync((nint)id);

				if (!string.IsNullOrEmpty(result))
				{
					var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IList<ComicResult.Result>>(result));

					if (data != null)
					{
						return data.Select(p => new Comic
						{
							Thumb = $"{p.Thumbnail.Path}.{p.Thumbnail.Extension}",
							Name = p.Title
						}).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Native error library: {ex.Message}");
				throw ex;
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
