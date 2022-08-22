
namespace CoronaApp.Services.Dtos;

public record LocationPostDto(
    DateTime StartDate,
    DateTime EndDate, 
    string City,
    string Address
    );
