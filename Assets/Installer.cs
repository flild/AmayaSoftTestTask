using CardQuiz.data;
using CardQuiz.Tools;
using UnityEngine;
using Zenject;

namespace CardQuiz
{
    public class Installer : MonoInstaller
    {
        [SerializeField]
        private CardsContentDataSO _content;
        [SerializeField]
        private LevelsSizeDataSO _levelSettings;
        [SerializeField]
        private GridDrawer _gridDrawer;
        [SerializeField]
        private ParticleSystem _starParticle;
        [SerializeField]
        private InputReaderSO _inputReader;


        private void OnValidate()
        {
            foreach (var level in _levelSettings.Levels)
            {
                if (level.x * level.y > _content.CardsContent.Count)
                {
                    Debug.LogError("карточек с контентом меньше, чем ячеек на уровне " + level);
                }
            }
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameLogic>().AsSingle();
            Container.Bind<CardsContentDataSO>().FromInstance(_content).AsSingle();
            Container.Bind<LevelsSizeDataSO>().FromInstance(_levelSettings).AsSingle();
            Container.Bind<GridDrawer>().FromInstance(_gridDrawer).AsSingle();
            Container.Bind<ParticleSystem>().FromInstance(_starParticle).AsSingle();
            Container.Bind<InputReaderSO>().FromInstance(_inputReader).AsSingle();
            
        }
    }
}
