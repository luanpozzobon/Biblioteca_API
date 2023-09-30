using System.ComponentModel.DataAnnotations;


namespace Biblioteca_API.models;

public class Supplier
{
	private int _id;
	private string? _name;
	private string? _contact;
	private DateTime _contractStart;
	private DateTime _contractEnd;
	private List<string>? _providedBooks; // TODO - Definir o tipo de dado {String / Livro}
	private string? _contractStatus;

	[Key]
	public int Id
	{
		get => _id;
		set => _id = value;
	}

	public string Name
	{
		get => _name;
		set => _name = value;
	}

	public string Contact
	{
		get => _contact;
		set => _contact = value;
	}

	public DateTime ContractStart
	{
		get => _contractStart;
		set => _contractStart = value;
	}

	public DateTime ContractEnd
	{
		get => _contractEnd;
		set => _contractEnd = value;
	}

	public List<string> providedBooks
	{
		get => _providedBooks;
		set => _providedBooks = value;
	}

	public string ContractStatus
	{
		get => _contractStatus;
		set => _contractStatus = value;
	}
}