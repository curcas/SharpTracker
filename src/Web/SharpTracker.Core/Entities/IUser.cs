using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTracker.Core.Entities
{
	public interface IUser
	{
		int Id { get; set; }
		string Name { get; set; }
		string Password { get; set; }
		string Salt { get; set; }
		IList<IToken> Tokens { get; set; }
		ILocation Location { get; set; }
	}
}
