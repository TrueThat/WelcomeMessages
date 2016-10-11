using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Color = UnityEngine.Color;

namespace TrueThat.WelcomeMessage
{
    public class Welcome : RocketPlugin<WelcomeConfiguration>
    {
        public static Welcome Instance;
        private Color WelcomeColor1;
        private Color WelcomeColor2;
        private Color WelcomeColor3;
        private Color WelcomeColor4;

        protected override void Load()
        {
            Instance = this;

            if (Welcome.Instance.Configuration.Instance.Enabled)
            {
                WelcomeColor1 = ParseColor(Instance.Configuration.Instance.WelcomeColor1);
                WelcomeColor2 = ParseColor(Instance.Configuration.Instance.WelcomeColor2);
                WelcomeColor3 = ParseColor(Instance.Configuration.Instance.WelcomeColor3);
                WelcomeColor4 = ParseColor(Instance.Configuration.Instance.WelcomeColor4);
                Logger.LogWarning("======================================");
                Logger.LogWarning("|     WelcomeMessage : Enabled       |");
                Logger.LogWarning("======================================");
                U.Events.OnPlayerConnected += OnPlayerConnected;
            }
            else
            {
                Logger.LogWarning("======================================");
                Logger.LogWarning("|     WelcomeMessage : Disabled      |");
                Logger.LogWarning("======================================");
            }

            Instance.Configuration.Save();
        }
        protected override void  Unload()
        {
                Logger.LogWarning("=======================================");
                Logger.LogWarning("|     WelcomeMessage : Unloading      |");
                Logger.LogWarning("=======================================");

            if (Welcome.Instance.Configuration.Instance.Enabled)
            {
                 U.Events.OnPlayerConnected -= OnPlayerConnected;
            }

        }
        internal Color ParseColor(string color)
        {
            if (color == null)
            return Color.green;
            switch (color.Trim().ToLower())
            {
                case "black":
                    return Color.black;
                case "blue":
                    return Color.blue;
                case "cyan":
                    return Color.cyan;
                case "grey":
                    return Color.grey;
                case "green":
                    return Color.green;
                case "gray":
                    return Color.gray;
                case "magenta":
                    return Color.magenta;
                case "red":
                    return Color.red;
                case "white":
                    return Color.white;
                case "yellow":
                    return Color.yellow;
                case "gold":
                    return new Color(1.0f, 0.843137255f, 0f);
                default:
                    float r;
                    float g;
                    float b;
                    string[] colors = color.Split(',');
                    return (colors.Length == 3 && float.TryParse(colors[0], out r) && float.TryParse(colors[1], out g) && float.TryParse(colors[2], out b) && r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255) ? new Color(r / 255, g / 255, b / 255) : Color.green;
            }
        }
        public void OnPlayerConnected(UnturnedPlayer player)
        {
            UnturnedChat.Say(player, Configuration.Instance.welcomemsg1, WelcomeColor1);
            UnturnedChat.Say(player, Configuration.Instance.welcomemsg2, WelcomeColor2);
            UnturnedChat.Say(player, Configuration.Instance.welcomemsg3, WelcomeColor3);
            UnturnedChat.Say(player, Configuration.Instance.welcomemsg4, WelcomeColor4);
        }
    }
}
