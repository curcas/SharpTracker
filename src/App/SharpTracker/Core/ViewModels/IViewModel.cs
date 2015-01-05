using System.Collections.Generic;

namespace SharpTracker.Core.ViewModels
{
	public interface IViewModel
	{
		bool IsValid();
		IList<string> GetValidationMessages();
	}
}