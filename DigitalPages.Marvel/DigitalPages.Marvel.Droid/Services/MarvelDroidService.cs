using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigitalPages.Marvel.Constants;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Core.Models;
using MarvelApi = ME.Rmenezes.Digitalpages.Characters;

namespace DigitalPages.Marvel.Droid.Services
{
	public class MarvelDroidService : IMarvelService
	{
		private readonly MarvelApi _marvelApi;
		
		public MarvelDroidService()
		{
			var timestamp = "1234";
			var hash = GetMd5($"{timestamp}{AppSettings.ApiPrivateKey}{AppSettings.ApiPublicKey}");
			_marvelApi = new MarvelApi(AppSettings.ApiKey,
									   AppSettings.ApiUrl,
									   timestamp,
									   hash);
		}

		public Task<Character> GetById(long id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Character>> GetCharacters(string name = "", int skip = 0, int limit = 20)
		{
			try
			{
				var result = _marvelApi.GetAll(name);

				if (result == null)
				{
				}
			}
			catch (Exception ex)
			{

			}

			return null;
		}

		public Task<ICollection<Comic>> GetComicsByIdCharacter(long id, int skip = 0, int limit = 20)
		{
			throw new NotImplementedException();
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
