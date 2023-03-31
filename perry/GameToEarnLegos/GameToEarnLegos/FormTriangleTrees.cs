using GameToEarnLegos.Tiles;
using System.Data.Common;
using System.Diagnostics.Metrics;

namespace GameToEarnLegos
{
    public partial class FormTriangleTrees : Form
    {
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
            MenuChoices.Add(new ButtonsInMenu("Exit"));
            OptionChoices.Add(new ButtonsInMenu("Cheats"));
            OptionChoices.Add(new ButtonsInMenu("Win All Games"));
            OptionChoices.Add(new ButtonsInMenu("Return"));
            foreach(Level level in levels)
            {
                LevelChoices.Add(new ButtonsInMenu(level));
            }
            LevelChoices.Add(new ButtonsInMenu("Return"));
            foreach (ButtonsInMenu choice in MenuChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");
                choice.NameBitmapRed = NameInBitmap(choice.Name, "red");

            }
            foreach (ButtonsInMenu choice in OptionChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");
                choice.NameBitmapRed = NameInBitmap(choice.Name, "red");
            }
            foreach (ButtonsInMenu choice in LevelChoices)
            {
                choice.NameBitmap = NameInBitmap(choice.Name, "white");
                choice.NameBitmapRed = NameInBitmap(choice.Name, "red");
            }
            Start();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public List<Bitmap> NameInBitmap(string name, string color)
        {
            string nameLower = name.ToLower();

            List<Bitmap> Bitmaps = new List<Bitmap>();
            for (int i = 0; i < nameLower.Length; i++)
            {
                char c = nameLower[i];
                if (color == "white")
                {
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
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'o':
                            Bitmaps.Add(Resources.Image_O);
                            break;
                        case 'p':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'q':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'r':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 's':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 't':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'u':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'v':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'w':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'x':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'y':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        case 'z':
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                        default:
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                    }
                }
                else if(color == "red")
                {
                    switch (c)
                    {
                        case 'a':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'b':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'c':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'd':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'e':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'f':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'g':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'h':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'i':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'j':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'k':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'l':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'm':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'n':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'o':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'p':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'q':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'r':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 's':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 't':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'u':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'v':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'w':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'x':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'y':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        case 'z':
                            Bitmaps.Add(Resources.Image_Tree1);
                            break;
                        default:
                            Bitmaps.Add(Resources.Image_Tree2);
                            break;
                    }
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
            using (Bitmap frontLayerBmp = new Bitmap(this.Size.Width, this.Size.Height))
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
                        this.ClientRectangle.X * _currentGame.ScaleFactor,
                        this.ClientRectangle.Y * _currentGame.ScaleFactor,
                        this.ClientRectangle.Width * _currentGame.ScaleFactor,
                        this.ClientRectangle.Height * _currentGame.ScaleFactor);
                }
            }
        }

        
    }
}