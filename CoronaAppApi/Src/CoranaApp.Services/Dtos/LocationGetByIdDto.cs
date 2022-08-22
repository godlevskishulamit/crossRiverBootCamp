
namespace CoronaApp.Services.Dtos;

public record LocationGetByIdDto(
    int Id,
    DateTime StartDate,
    DateTime EndDate,
    string City,
    string Address
    );
