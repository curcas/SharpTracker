using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTracker.Core.Entities;

namespace SharpTracker.Entities
{
	public class Token : IToken
	{
		public int Id { get; set; }
		public IUser User { get; set; }
		public string Value { get; set; }
	}
}
