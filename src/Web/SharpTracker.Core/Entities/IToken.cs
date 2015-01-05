namespace SharpTracker.Core.Entities
{
	public interface IToken
	{
		int Id { get; set; }
		IUser User { get; set; }
		string Value { get; set; }
	}
}