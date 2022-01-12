using Utils.Services;

namespace ExperienceSystem
{
    public interface IPlayerExperience : IService
    {
        int Level { get; }
        int Experience { get; }
        int ExperienceToNextLevel { get; }

        void AddExperience(int count);
        void AddLevel();
    }
}