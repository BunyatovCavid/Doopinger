using BubbleAPi.Dtoes;

namespace BubbleAPi.Interfaces
{
    public interface IUser
    {
        public Task<bool> CreateUSer(UserPostDto dto);

    }
}
