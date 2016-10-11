using Rocket.API;


namespace TrueThat.WelcomeMessage
{
    public class WelcomeConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string WelcomeColor1;
        public string welcomemsg1;
        public string WelcomeColor2;
        public string welcomemsg2;
        public string WelcomeColor3;
        public string welcomemsg3;
        public string WelcomeColor4;
        public string welcomemsg4;

        public void LoadDefaults()
        {
            Enabled = true;
            WelcomeColor1 = "gold";
            welcomemsg1 = "This is a Text Message";
            WelcomeColor2 = "gold";
            welcomemsg2 = "This is a Text Message";
            WelcomeColor3 = "gold";
            welcomemsg3 = "This is a Text Message";
            WelcomeColor4 = "gold";
            welcomemsg4 = "This is a Text Message";
        }
    }
}
