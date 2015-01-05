using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTracker.Core.Entities;

namespace SharpTracker.Entities
{
    public class User : IUser
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public string Password { get; set; }
	    public string Salt { get; set; }
	    public IList<IToken> Tokens { get; set; }
	    public ILocation Location { get; set; }
    }
}
