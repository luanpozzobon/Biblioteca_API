using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models;

public class StudyRoom
{
	private int _roomNumber;
	private int _capacity;
	private bool _available; // TODO - Definir status de acordo com uso das salas.

	[Key]
	public int RoomNumber
	{
		get => _roomNumber;
		set => _roomNumber = value;
	}

	public int Capacity
	{
		get => _capacity;
		set => _capacity = value;
	}

	public bool IsAvailable
	{
		get => _available;
		set => _available = value;
	}
}