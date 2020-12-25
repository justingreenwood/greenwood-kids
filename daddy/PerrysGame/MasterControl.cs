using System.Drawing;
using System.Windows.Forms;

namespace PerrysGame
{
    public static class MasterControl
    {
        private static FormMyGame _form;
        public static float Zoom = 1.0f;

        public static void UseForm(FormMyGame form)
        {
            _form = form;
        }

        public static void SendEvent(GameStateChangeEventType eventType, object data = null)
        {
            _form.PerformEventChange(eventType, data);
        }
    }

    public enum GameStateChangeEventType
    {
        Play,
        Quit,
        HighScores,
        Menu
    }
}
