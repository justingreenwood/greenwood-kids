namespace GameToEarnLegos
{
    public partial class FormTriangleTrees : Form
    {
        private GameController gameController;
        private MenuController menuController;
        //private TestGameController _testing;
        private IGameController _currentGame;

        public FormTriangleTrees()
        {
            InitializeComponent();           

            //_testing = new TestGameController(this);
            gameController = new GameController(this);
            menuController = new MenuController(this);
           // _currentGame = _testing;
            _currentGame = gameController;
            



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