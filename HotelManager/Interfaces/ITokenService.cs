using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(Guest guest);
    }
}
