using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalPages.Marvel.Core.Models;

namespace DigitalPages.Marvel.Core.Interfaces
{
	public interface IMarvelService
	{
		Task<ICollection<Character>> GetCharacters(string name = "", int skip = 0, int limit = 20);
		Task<Character> GetById(long id);
		Task<ICollection<Comic>> GetComicsByIdCharacter(long id, int skip = 0, int limit = 20);
	}
}
