using GameToEarnLegos.Save;
using GameToEarnLegos.Tiles;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace GameToEarnLegos
{
    public partial class FormTriangleTrees : Form
    {
        private AudioPlaybackEngine audioEngine = new AudioPlaybackEngine();
        private SoundManager soundManager = new SoundManager();
        private GameController gameController;
        private MenuController menuController;
        //private TestGameController _testing;
        private IGameController _currentGame;
        public ILevel currentLevel;
        public Level1 level1 = new Level1();
        public Level2 level2 = new Level2();
        public Level3 level3 = new Level3();
        public Level4 level4 = new Level4();
        public Level5 level5 = new Level5();
        public Level6 level6 = new Level6();
        public Level7 level7 = new Level7();
        public Level8 level8 = new Level8();
        public Level9 level9 = new Level9();
        public Level10 level10 = new Level10();
        public TestLevel testLevel = new TestLevel();
        public List<ILevel> levels = new List<ILevel>();
        public List<ButtonsInMenu> MenuChoices = new List<ButtonsInMenu>();
        public List<ButtonsInMenu> OptionChoices = new List<ButtonsInMenu>();
        public List<ButtonsInMenu> LevelChoices = new List<ButtonsInMenu>();

        public bool CHEATS => menuController.cheatsOn;


        public FormTriangleTrees()
        {
            InitializeComponent();
            if (DateTime.Now.Month >= 12)
            {
                soundManager.loadSound(GameSounds.MenuMusic, Resources.Sound_Christmas, ".mp3", audioEngine.Format);
                soundManager.loadSound(GameSounds.GameMusic, Resources.Sound_JingleBells, ".mp3", audioEngine.Format);
            }
            else
            {
                soundManager.loadSound(GameSounds.MenuMusic, Resources.Music_InMenu, ".mp3", audioEngine.Format);
                soundManager.loadSound(GameSounds.GameMusic, Resources.Music_InGame, ".mp3", audioEngine.Format);
            }
            soundManager.loadSound(GameSounds.LastLevelMusic, Resources.Music_InLastLevel, ".mp3", audioEngine.Format);
            soundManager.loadSound(GameSounds.ShootGun1, Resources.Sound_Shoot, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.Bleah, Resources.Sound_Bleah, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.OhYeah, Resources.Sound_OhYeah, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.Wfff, Resources.Sound_Wfff, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.CHL, Resources.Sound_Chl, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.RefillWater, Resources.Sound_RefillWater, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.Errr, Resources.Sound_Errr, ".wav", audioEngine.Format);
            soundManager.loadSound(GameSounds.ChChh, Resources.Sound_ChChh, ".wav", audioEngine.Format);
            
            //_testing = new TestGameController(this);
            gameController = new GameController(this);
            menuController = new MenuController(this);
            //_currentGame = _testing;
            _currentGame = menuController;
            levels.Add(level1);
            levels.Add(level2);
            levels.Add(level3);
            levels.Add(level4);
            levels.Add(level5);
            levels.Add(level6);
            levels.Add(level7);
            levels.Add(level8);
            levels.Add(level9);
            levels.Add(level10);
            levels.Add(testLevel);

            MenuChoices.Add(new ButtonsInMenu("Play"));
            MenuChoices.Add(new ButtonsInMenu("Options"));
            MenuChoices.Add(new ButtonsInMenu("Save"));
            MenuChoices.Add(new ButtonsInMenu("Load"));
            MenuChoices.Add(new ButtonsInMenu("Exit"));
            OptionChoices.Add(new ButtonsInMenu("Cheats"));
            OptionChoices.Add(new ButtonsInMenu("Win All Games"));
            OptionChoices.Add(new ButtonsInMenu("Return"));
            foreach (Level level in levels)
            {
                LevelChoices.Add(new ButtonsInMenu(level));
            }
            LevelChoices.Add(new ButtonsInMenu("Return"));
            foreach (ButtonsInMenu choice in MenuChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");

            }
            foreach (ButtonsInMenu choice in OptionChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");
            }
            foreach (ButtonsInMenu choice in LevelChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");
            }
            Start();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Size = GetSmallestScreenSize();
        }

        public void Save()
        {
            var savedGame = new SavedGame
            {
                Name = "poopy"
            };
            foreach (var level in this.levels)
            {
                savedGame.Levels.Add(new SavedGame.SavedLevel
                {
                    Name = level.Name,
                    CurrentScore = level.CurrentScore,
                    HighScore = level.HighScore,
                    IsWon = level.IsWon,
                });
            }
            savedGame.Save();
        }

        public void LoadLatest()
        {
            var savedGames = SavedGame.GetSavedGames();
            if (savedGames.Count > 0)
            {
                var sg = savedGames.MaxBy(x => x.TimeSaved);
                foreach (var level in this.levels)
                {
                    var savedLevel = sg.Levels.FirstOrDefault(x=> x.Name == level.Name);
                    if (savedLevel != null)
                    {
                        level.CurrentScore = savedLevel.CurrentScore;
                        level.HighScore = savedLevel.HighScore;
                        level.IsWon = savedLevel.IsWon;
                    }
                }
            }
        }

        public AudioPlaybackEngine AudioEngine => audioEngine;
        public SoundManager SoundManager => soundManager;

        public Size GetSmallestScreenSize()
        {
            return new Size(Screen.AllScreens.Min(x => x.WorkingArea.Width), Screen.AllScreens.Min(x => x.WorkingArea.Height));
        }

        private CachedSoundSampleProvider _currentMusic = null;
        public void PlayMusic(GameSounds soundName)
        {
            CachedSoundSampleProvider sound = null;
            if (_currentMusic != null)
            {
                audioEngine.StopSoundInstance(_currentMusic);
                _currentMusic = null;
            }
            sound = soundManager.createSoundInstance(soundName);
            if (sound != null)
            {
                audioEngine.PlaySoundInstance(sound);
                _currentMusic = sound;
            }
        }
        public void PlaySound(GameSounds soundName)
        {
            var sound = soundManager.createSoundInstance(soundName, 10, false);
            if (sound != null)
            {
                audioEngine.PlaySoundInstance(sound);
            }
        }

        public List<Bitmap> NameInBitmap(string name, string color)
        {
            string nameLower = name.ToLower();

            List<Bitmap> Bitmaps = new List<Bitmap>();
            for (int i = 0; i < nameLower.Length; i++)
            {
                char c = nameLower[i];

                switch (c)
                {
                    case 'a':
                        Bitmaps.Add(Resources.Image_A);
                        break;
                    case 'b':
                        Bitmaps.Add(Resources.Image_B);
                        break;
                    case 'c':
                        Bitmaps.Add(Resources.Image_C);
                        break;
                    case 'd':
                        Bitmaps.Add(Resources.Image_D);
                        break;
                    case 'e':
                        Bitmaps.Add(Resources.Image_E);
                        break;
                    case 'f':
                        Bitmaps.Add(Resources.Image_F);
                        break;
                    case 'g':
                        Bitmaps.Add(Resources.Image_G);
                        break;
                    case 'h':
                        Bitmaps.Add(Resources.Image_H);
                        break;
                    case 'i':
                        Bitmaps.Add(Resources.Image_I);
                        break;
                    case 'j':
                        Bitmaps.Add(Resources.Image_J);
                        break;
                    case 'k':
                        Bitmaps.Add(Resources.Image_K);
                        break;
                    case 'l':
                        Bitmaps.Add(Resources.Image_L);
                        break;
                    case 'm':
                        Bitmaps.Add(Resources.Image_M);
                        break;
                    case 'n':
                        Bitmaps.Add(Resources.Image_N);
                        break;
                    case 'o':
                        Bitmaps.Add(Resources.Image_O);
                        break;
                    case 'p':
                        Bitmaps.Add(Resources.Image_P);
                        break;
                    case 'q':
                        Bitmaps.Add(Resources.Image_Q);
                        break;
                    case 'r':
                        Bitmaps.Add(Resources.Image_R);
                        break;
                    case 's':
                        Bitmaps.Add(Resources.Image_S);
                        break;
                    case 't':
                        Bitmaps.Add(Resources.Image_T);
                        break;
                    case 'u':
                        Bitmaps.Add(Resources.Image_U);
                        break;
                    case 'v':
                        Bitmaps.Add(Resources.Image_V);
                        break;
                    case 'w':
                        Bitmaps.Add(Resources.Image_W);
                        break;
                    case 'x':
                        Bitmaps.Add(Resources.Image_X);
                        break;
                    case 'y':
                        Bitmaps.Add(Resources.Image_Y);
                        break;
                    case 'z':
                        Bitmaps.Add(Resources.Image_Z);
                        break;
                    default:
                        Bitmaps.Add(Resources.Image_Tree1);
                        break;
                }

            }
            return Bitmaps;


        }

        public void Start()
        {
            _currentGame.Start();
            timerGameLoop.Enabled = true;
        }

        public void Stop()
        {
            _currentGame.Stop();
            timerGameLoop.Enabled = false;
        }

        private void DrawTheGame(Graphics g)
        {
            _currentGame.DrawTheGame(g);
        }


        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            if (menuController.willPlay == true)
            {
                _currentGame = gameController;
                currentLevel = menuController.levelChoice;

                menuController.willPlay = false;
                Start();
            }
            if (gameController.goToMenu == true)
            {
                _currentGame = menuController;
                Start();
                gameController.goToMenu = false;
            }
            _currentGame.Tick();
        }

        private void FormTriangleTrees_KeyDown(object sender, KeyEventArgs e)
        {
            _currentGame.KeyDown(sender, e);
        }

        private void FormTriangleTrees_KeyUp(object sender, KeyEventArgs e)
        {
            _currentGame.KeyUp(sender, e);
        }
        private void FormTriangleTrees_MouseDown(object sender, MouseEventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            using (Bitmap frontLayerBmp = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height))
            {
                using (var frontLayer = Graphics.FromImage(frontLayerBmp))
                {
                    frontLayer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    frontLayer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    frontLayer.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                    frontLayer.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                    frontLayer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

                    try
                    {
                        DrawTheGame(frontLayer);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        System.Diagnostics.Debug.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                        System.Diagnostics.Debugger.Break();
                    }

                    g.DrawImage(frontLayerBmp,
                        this.ClientRectangle.X,
                        this.ClientRectangle.Y,
                        this.ClientRectangle.Width,
                        this.ClientRectangle.Height);
                }
            }
        }


    }
}