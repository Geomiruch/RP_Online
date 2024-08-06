using RpClient.DTO;
using RpClient.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RpClient.Views.Character
{
    class CharactersViewModel : INotifyPropertyChanged
    {
        private CharacterService _characterService;
        private List<CharacterDto> _characters;
        public List<CharacterDto> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public CharactersViewModel()
        {
            _characterService = new CharacterService();
            Characters = _characterService.GetAllAsync().Result.Characters;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
