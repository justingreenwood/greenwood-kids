using System.Drawing;

namespace PerrysGame
{
    public static class ScreenInfo
    {
        private static FormMyGame _form;
        public static float Zoom = 1.0f;

        public static void UseForm(FormMyGame form)
        {
            _form = form;
        }

        public static Size ClientSize
        {
            get
            {
                return _form.ClientSize;
            }
        }

        public static Rectangle ClientRectangle => new Rectangle(0, 0, _form.Size.Width, _form.Size.Height);


    }
}
