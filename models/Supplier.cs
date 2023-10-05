using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Biblioteca_API.models;

public class Supplier
{
	private int _id;
	private string? _name;
	private string? _contact;
	private DateTime _contractStart;
	private DateTime _contractEnd;
	private bool _contractStatus;

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id
	{
		get => _id;
		set => _id = value;
	}

	[Required]
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

	[Required]
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

	[Required]
	public bool ContractStatus
	{
		get => _contractStatus;
		set => _contractStatus = value;
	}
}