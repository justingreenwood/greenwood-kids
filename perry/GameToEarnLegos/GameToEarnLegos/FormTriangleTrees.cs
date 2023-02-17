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
        public Level5 level5 = new Level5();
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
            levels.Add(level5);
            MenuChoices.Add(new ButtonsInMenu("Play"));
            MenuChoices.Add(new ButtonsInMenu("Options"));
            MenuChoices.Add(new ButtonsInMenu("Exit"));
            OptionChoices.Add(new ButtonsInMenu("Cheats"));
            OptionChoices.Add(new ButtonsInMenu("Win All Games"));
            OptionChoices.Add(new ButtonsInMenu("Return"));
            


            Start();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                if (menuController.levelChoice == 0)
                {
                    currentLevel = level1;
                }
                else if (menuController.levelChoice == 1)
                {
                    currentLevel = level2;
                }
                else if (menuController.levelChoice == 2)
                {
                    currentLevel = level3;
                }
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